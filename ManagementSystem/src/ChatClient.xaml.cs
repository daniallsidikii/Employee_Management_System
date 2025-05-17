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
                await client.ConnectAsync("192.168.1.107", 5000); // Server IP here
                stream = client.GetStream();

                // Send username
                string username = txtUsername.Text.Trim();
                byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
                await stream.WriteAsync(usernameBytes, 0, usernameBytes.Length);

                AddMessage("Connected to server as " + username, false);
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

            // Prepare message format based on target user
            if (!string.IsNullOrEmpty(target) && target != "Everyone")
            {
                message = $"@{target} {message}"; // Private message format
            }
            else
            {
                message = $"@Everyone {message}"; // Broadcast message format
            }

            byte[] msgBuffer = Encoding.UTF8.GetBytes(message);
            await client.GetStream().WriteAsync(msgBuffer, 0, msgBuffer.Length);

            // Show the sent message immediately on the client UI (right-aligned)
            string displayMsg = (target == "Everyone" || string.IsNullOrEmpty(target)) ?
                $"[Everyone] You to Everyone: {txtMessage.Text.Trim()}" :
                $"[Private] You to {target}: {txtMessage.Text.Trim()}";

            AddMessage(displayMsg, true);  // true = right-aligned (sent message style)
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
            byte[] buffer = new byte[8192];  // Larger buffer for files etc.

            try
            {
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;  // Disconnected

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Handle user list update command
                    if (msg.StartsWith("!users "))
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
                    // Handle file transfer
                    else if (msg.StartsWith("!file|"))
                    {
                        int newlineIndex = msg.IndexOf('\n');
                        if (newlineIndex == -1) continue; // Incomplete header, wait for next read

                        string header = msg.Substring(0, newlineIndex);
                        string[] parts = header.Split('|');
                        if (parts.Length < 4) continue;

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

                        string saveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                        Directory.CreateDirectory(saveFolder);
                        string savePath = Path.Combine(saveFolder, fileName);
                        File.WriteAllBytes(savePath, fileData);

                        Dispatcher.Invoke(() =>
                            AddMessage($"[File received from {senderName}] {fileName} saved to {savePath}", false));
                    }
                    // Handle regular chat messages
                    else
                    {
                        // Ignore own echoed messages from server to prevent duplicates
                        if (!msg.StartsWith($"[Everyone] You to Everyone:") &&
                            !msg.StartsWith($"[Private] You to ") &&
                            !msg.Contains($"You to "))
                        {
                            Dispatcher.Invoke(() => AddMessage(msg, false));
                        }
                    }
                }
            }
            catch
            {
                Dispatcher.Invoke(() => AddMessage("Disconnected from server.", false));
            }
        }


        private void AddMessage(string message, bool isSentByMe)
        {
            Dispatcher.Invoke(() =>
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = message;

                // Apply custom style from XAML
                item.Style = isSentByMe
                    ? (Style)this.Resources["SentMessageStyle"]
                    : (Style)this.Resources["ReceivedMessageStyle"];

                lstMessages.Items.Add(item);
                lstMessages.ScrollIntoView(item);
            });
        }

        private async void SendFile_Click(object sender, RoutedEventArgs e)
        {
            if (client == null || !client.Connected) return;

            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                string fileName = Path.GetFileName(filePath);
                byte[] fileBytes = File.ReadAllBytes(filePath);
                int fileSize = fileBytes.Length;

                string header = $"!file|{fileName}|{fileSize}|{userName}\n";
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);

                await stream.WriteAsync(headerBytes, 0, headerBytes.Length);
                await stream.WriteAsync(fileBytes, 0, fileBytes.Length);

                AddMessage($"[File sent] {fileName} ({fileSize} bytes)", true);
            }
        }
    }
}





