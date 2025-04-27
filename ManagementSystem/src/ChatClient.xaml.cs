using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows.Media;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


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
                await client.ConnectAsync("192.168.1.108", 5000); // Server's Ip here
                stream = client.GetStream();

                // Send username as first message
                string username = txtUsername.Text.Trim();
                byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
                await stream.WriteAsync(usernameBytes, 0, usernameBytes.Length);

                lstMessages.Items.Add("Connected to server as " + username);

                
                
                ReceiveMessages(); // Start receiving in background
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


            if (!string.IsNullOrEmpty(target))
                message = $"@{target} {message}";

            byte[] msgBuffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(msgBuffer, 0, msgBuffer.Length);
            txtMessage.Clear();

            // lstMessages.Items.Add(target + message); // to update sender listbox also
        }

        private async void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

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


                            // Add "Everyone" first
                            comboBoxUsers.Items.Add("Everyone");
                            foreach (var u in users)
                            {
                                if (u != userName) // don't add self
                                    comboBoxUsers.Items.Add(u);
                            }
                            comboBoxUsers.SelectedIndex = 0; // Select "Everyone" by default
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
        

    }
}