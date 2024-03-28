using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MessengerServerSide
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ip = IPAddress.Parse("127.0.0.1");
            var port = 27001;

            var listenerEP = new IPEndPoint(ip, port);

            var listener = new TcpListener(listenerEP);
            listener.Start();

            Console.WriteLine($"{listener.Server.LocalEndPoint} Listener Started .....");

            var clients = new List<TcpClient>();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = Task.Run(async () =>
                {
                    var br = new BinaryReader(client.GetStream());
                    var username = br.ReadString();

                    Console.WriteLine(username + " connected...");

                    clients.Add(client);

                    var reader = new BinaryReader(client.GetStream());

                    while (true)
                    {
                        try
                        {
                            var readString = reader.ReadString();
                            var targetUsername = readString.Split(' ')[0];
                            var message = readString.Substring(targetUsername.Length + 1);

                            var targetClient = clients.FirstOrDefault(c => ((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString() == targetUsername);
                            if (targetClient != null)
                            {
                                var writer = new BinaryWriter(targetClient.GetStream());
                                writer.Write($"{username}: {message}");
                            }
                        }
                        catch (IOException)
                        {
                            Console.WriteLine(username + " disconnected.");
                            clients.Remove(client);
                            break;
                        }
                    }
                });
            }
        }
    }
}
