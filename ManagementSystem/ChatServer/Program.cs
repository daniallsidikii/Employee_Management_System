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
        byte[] buffer = new byte[8192]; // Large buffer for file data

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

                // Check if it's a file transfer
                string headerCheck = Encoding.UTF8.GetString(buffer, 0, Math.Min(bytes, 6));
                if (headerCheck.StartsWith("!file|"))
                {
                    int newlineIndex = Array.IndexOf(buffer, (byte)'\n');
                    if (newlineIndex == -1) continue; // Invalid or incomplete header

                    string header = Encoding.UTF8.GetString(buffer, 0, newlineIndex);
                    string[] parts = header.Split('|');
                    if (parts.Length < 4) continue;

                    string fileName = parts[1];
                    int fileSize = int.Parse(parts[2]);
                    string sender = parts[3];

                    int headerLength = newlineIndex + 1;
                    byte[] fileData = new byte[fileSize];

                    int alreadyRead = bytes - headerLength;
                    if (alreadyRead > 0)
                        Array.Copy(buffer, headerLength, fileData, 0, alreadyRead);

                    while (alreadyRead < fileSize)
                    {
                        int read = stream.Read(fileData, alreadyRead, fileSize - alreadyRead);
                        if (read == 0) break;
                        alreadyRead += read;
                    }

                    // Broadcast file to all except sender
                    foreach (var clientPair in clients)
                    {
                        if (clientPair.Key != sender)
                        {
                            try
                            {
                                var targetStream = clientPair.Value.GetStream();
                                byte[] headerBytes = Encoding.UTF8.GetBytes(header + "\n");
                                targetStream.Write(headerBytes, 0, headerBytes.Length);
                                targetStream.Write(fileData, 0, fileData.Length);
                            }
                            catch
                            {
                                // Handle individual failures silently
                            }
                        }
                    }

                    // Optional: Confirm to sender
                    byte[] confirmMsg = Encoding.UTF8.GetBytes($"[File broadcasted] {fileName}");
                    client.GetStream().Write(confirmMsg, 0, confirmMsg.Length);
                    continue;
                }

                // Otherwise, treat it as text
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                Console.WriteLine($"Received from {username}: {message}");

                if (message.StartsWith("@Everyone "))
                {
                    string actualMsg = message.Substring("@Everyone ".Length);
                    foreach (var clientPair in clients)
                    {
                        if (clientPair.Key != username)
                        {
                            try
                            {
                                byte[] msgBuffer = Encoding.UTF8.GetBytes($"[Everyone] {username}: {actualMsg}");
                                clientPair.Value.GetStream().Write(msgBuffer, 0, msgBuffer.Length);
                            }
                            catch { }
                        }
                    }

                    byte[] senderMsg = Encoding.UTF8.GetBytes($"[Everyone] You to Everyone: {actualMsg}");
                    stream.Write(senderMsg, 0, senderMsg.Length);
                }
                else if (message.StartsWith("@"))
                {
                    int spaceIndex = message.IndexOf(' ');
                    if (spaceIndex > 1)
                    {
                        string targetUser = message.Substring(1, spaceIndex - 1);
                        string actualMsg = message.Substring(spaceIndex + 1);

                        if (clients.TryGetValue(targetUser, out var targetClient))
                        {
                            string sendText = $"[Private] {username}: {actualMsg}";
                            byte[] msgBuffer = Encoding.UTF8.GetBytes(sendText);
                            targetClient.GetStream().Write(msgBuffer, 0, msgBuffer.Length);

                            byte[] selfBuffer = Encoding.UTF8.GetBytes($"[Private] You to {targetUser}: {actualMsg}");
                            stream.Write(selfBuffer, 0, selfBuffer.Length);
                        }
                    }
                }
                else
                {
                    // Optionally handle unformatted messages
                    Console.WriteLine("Unrecognized message format.");
                }

            }
        }
        catch
        {
            // Do nothing on error
        }

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
        catch { }
    }
}

