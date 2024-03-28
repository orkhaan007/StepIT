using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var ip = IPAddress.Parse("127.0.0.1");
        var port = 27001;
        var serverEP = new IPEndPoint(ip, port);

        var client = new TcpClient();
        client.Connect(serverEP);

        NetworkStream? clientStream = client.GetStream();
        BinaryWriter? writer = new BinaryWriter(clientStream);
        BinaryReader? reader = new BinaryReader(clientStream);

        _ = Task.Run(() =>
        {
            while (true)
                Console.WriteLine(reader.ReadString());
        });

        while (true)
        {
            var message = Console.ReadLine();
            writer.Write(message);
        }
    }
}
