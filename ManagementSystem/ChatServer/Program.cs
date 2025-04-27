using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;

var clients = new ConcurrentDictionary<string, TcpClient>();

TcpListener server = new TcpListener(IPAddress.Any, 5000);

server.Start();

Console.WriteLine("Server started on port 5000");

while (true)
{
    TcpClient client = server.AcceptTcpClient();
    _ = Task.Run(() =>
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        int nameLen = stream.Read(buffer, 0, buffer.Length);
        string username = Encoding.UTF8.GetString(buffer, 0, nameLen);
        clients.TryAdd(username, client);

        Console.WriteLine($"{username} connected.");
        BroadcastUserList();

        try
        {
            while (true)
            {
                int bytes = stream.Read(buffer, 0, buffer.Length);
                if (bytes == 0) break;

                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                Console.WriteLine($"{username} says {message}");

                string actualMsg;
                if (message.StartsWith("@Everyone"))
                {
                    actualMsg = message.Substring(10); // Extract the actual message
                    foreach (var clientPair in clients)
                    {
                        if (clientPair.Key != username) // Compare the usernames, not the TcpClient
                        {
                            try
                            {
                                byte[] msgBuffer = Encoding.UTF8.GetBytes($"[Everyone] {username} : {actualMsg}");
                                clientPair.Value.GetStream().Write(msgBuffer, 0, msgBuffer.Length);
                            }
                            catch
                            {
                                // Ignore errors
                            }
                        }
                    }

                    // Send the same message back to the sender
                    byte[] senderMsgBuffer = Encoding.UTF8.GetBytes($"[Everyone] You to Everyone : {actualMsg}");
                    client.GetStream().Write(senderMsgBuffer, 0, senderMsgBuffer.Length);
                }

                if (message.StartsWith("@")) // Private message
                {
                    int spaceIndex = message.IndexOf(' ');
                    if (spaceIndex > 1)
                    {
                        string targetUser = message.Substring(1, spaceIndex - 1);
                        actualMsg = message.Substring(spaceIndex + 1); // Extract the actual message

                        if (clients.TryGetValue(targetUser, out var targetClient))
                        {
                            string sendText = $"[Private] {username} : {actualMsg}";
                            byte[] msgBuffer = Encoding.UTF8.GetBytes(sendText);

                            targetClient.GetStream().Write(msgBuffer, 0, msgBuffer.Length);

                            // Send the same message to the sender (this is the new part)
                            byte[] senderMsgBuffer = Encoding.UTF8.GetBytes($"[Private] You to {targetUser} : {actualMsg}");
                            client.GetStream().Write(senderMsgBuffer, 0, senderMsgBuffer.Length);
                        }
                    }
                }
            }
        }
        catch { }
        clients.TryRemove(username, out _);
        client.Close();
        Console.WriteLine($"{username} disconnected.");
        BroadcastUserList();
    });
}

void BroadcastUserList()
{
    string userList = "!users " + string.Join(",", clients.Keys);
    byte[] userListBuffer = Encoding.UTF8.GetBytes(userList);

    foreach (var client in clients.Values)
    {
        try
        {
            client.GetStream().Write(userListBuffer, 0, userListBuffer.Length);
        }
        catch
        {
            // Ignore errors
        }
    }
}
