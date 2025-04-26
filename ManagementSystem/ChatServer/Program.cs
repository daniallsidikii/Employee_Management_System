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

                if (message.StartsWith("@"))
                {
                    int spaceIndex = message.IndexOf(' ');
                    if (spaceIndex > 1)
                    {
                        string targetUser = message.Substring(1, spaceIndex - 1);
                        string actualMsg = message.Substring(spaceIndex + 1);

                        if (clients.TryGetValue(targetUser, out var targetClient))
                        {
                            string sendText = $"[Private] {username} : {message}";
                            byte[] msgBuffer = Encoding.UTF8.GetBytes(sendText);

                            targetClient.GetStream().Write(msgBuffer, 0, msgBuffer.Length);
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
