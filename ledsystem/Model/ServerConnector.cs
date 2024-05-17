using System;
using System.Net.Sockets;
using System.Threading.Tasks;

public class ServerConnector
{ 
    public List<TcpClient> CreateTcpClientList(string serverIP, int minPort, int maxPort)
    {
        List<TcpClient> tcpClientList = new List<TcpClient>();

        for (int port = minPort; port <= maxPort; port++)
        {
            try
            {
                TcpClient client = new TcpClient(serverIP, port);
                tcpClientList.Add(client);
            }
            catch (Exception)
            {
                // Ignore les exceptions pour les ports non connectés et continue à essayer le prochain port
            }
        }

        return tcpClientList;
    }
}
