using System.Net.Sockets;

namespace MessengerServerSide.Models;

public class User
{
    public string? UserName { get; set; }
    public TcpClient? TcpClient { get; set; }

    public User(string userName, TcpClient tcpClient)
    {
        UserName = userName;
        TcpClient = tcpClient;
    }
}
