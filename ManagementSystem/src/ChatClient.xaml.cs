using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;

namespace Employee_Management_System
{
    public partial class ChatClient : Window
    {
        private TcpClient client;
        private NetworkStream stream;
        public string userName;

        public ChatClient(string username)
        {
            InitializeComponent();
            userName = username;
            txtUsername.Text = userName;
        }

        private void comboBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxUsers.SelectedItem != null)
            {
                txtTarget.Text = comboBoxUsers.SelectedItem.ToString();
            }
        }

        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync("192.168.100.24", 5000); // Server IP here
                stream = client.GetStream();

                // Send username
                string username = txtUsername.Text.Trim();
                byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
                await stream.WriteAsync(usernameBytes, 0, usernameBytes.Length);

                lstMessages.Items.Add("Connected to server as " + username);

                ReceiveMessages(); // Start background receiving
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting: " + ex.Message);
            }
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (client == null || !client.Connected) return;

            string message = txtMessage.Text.Trim();
            string target = txtTarget.Text.Trim();

            if (string.IsNullOrEmpty(message)) return;

            // Format message for private or group chat
            if (!string.IsNullOrEmpty(target) && target != "Everyone")
            {
                message = $"@{target} {message}"; // Private message
            }
            else
            {
                message = $"@Everyone {message}"; // Group broadcast
            }

            byte[] msgBuffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(msgBuffer, 0, msgBuffer.Length);

            txtMessage.Clear();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSend_Click(sender, new RoutedEventArgs());
            }
        }

        private async void ReceiveMessages()
        {
            byte[] buffer = new byte[4096];

            try
            {
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (msg.StartsWith("!users"))
                    {
                        string userList = msg.Substring(7);
                        var users = userList.Split(',');

                        Dispatcher.Invoke(() =>
                        {
                            comboBoxUsers.Items.Clear();
                            comboBoxUsers.Items.Add("Everyone");
                            foreach (var u in users)
                            {
                                if (u != userName)
                                    comboBoxUsers.Items.Add(u);
                            }
                            comboBoxUsers.SelectedIndex = 0;
                        });
                    }
                    else if (msg.StartsWith("!file|"))
                    {
                        int newlineIndex = msg.IndexOf('\n');
                        if (newlineIndex == -1) return; // incomplete header

                        string header = msg.Substring(0, newlineIndex);
                        string[] parts = header.Split('|');
                        if (parts.Length < 4) return;

                        string fileName = parts[1];
                        int fileSize = int.Parse(parts[2]);
                        string senderName = parts[3];

                        int headerLength = Encoding.UTF8.GetByteCount(header + "\n");
                        byte[] fileData = new byte[fileSize];

                        int alreadyRead = bytesRead - headerLength;
                        if (alreadyRead > 0)
                        {
                            Array.Copy(buffer, headerLength, fileData, 0, alreadyRead);
                        }

                        while (alreadyRead < fileSize)
                        {
                            int read = await stream.ReadAsync(fileData, alreadyRead, fileSize - alreadyRead);
                            if (read == 0) break;
                            alreadyRead += read;
                        }

                        string saveFolder;
                        // Determine the appropriate save folder based on the OS
                        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        {
                            // For Windows, get the Downloads folder path
                            saveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                        }
                        else if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                        {
                            // For macOS/Linux, the Downloads folder is usually under the home directory
                            saveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                        }
                        else
                        {
                            // Default to the application's directory for other platforms
                            saveFolder = "ReceivedFiles";
                        }

                        Directory.CreateDirectory(saveFolder); // Ensure the Downloads folder exists

                        string savePath = Path.Combine(saveFolder, fileName);
                        File.WriteAllBytes(savePath, fileData);

                        Dispatcher.Invoke(() =>
                        {
                            lstMessages.Items.Add($"[File received from {senderName}] {fileName} saved to {savePath}");
                        });
                    }

                    else
                    {
                        Dispatcher.Invoke(() =>
                        {
                            lstMessages.Items.Add(msg);
                        });
                    }
                }
            }
            catch
            {
                Dispatcher.Invoke(() =>
                {
                    lstMessages.Items.Add("Disconnected from server.");
                });
            }
        }
        private async void SendFile_Click(object sender, RoutedEventArgs e)
        {
            if (client == null || !client.Connected) return;

            var dialog = new Microsoft.Win32.OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                byte[] fileBytes = File.ReadAllBytes(filePath);
                int fileSize = fileBytes.Length;

                string header = $"!file|{fileName}|{fileSize}|{userName}\n";
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);

                // Send header
                await stream.WriteAsync(headerBytes, 0, headerBytes.Length);

                // Send file content
                await stream.WriteAsync(fileBytes, 0, fileBytes.Length);

                lstMessages.Items.Add($"[File sent] {fileName} ({fileSize} bytes)");
            }
        }
    }
}
