using System;
using System.Net.Sockets;
using System.Threading.Tasks;

public class ServerConnector
{
    public async Task<TcpClient> ConnectAsync(string serverIP, int serverPort)
    {
        try
        {
            TcpClient client = new TcpClient(serverIP, serverPort);
            return client;
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur lors de la connexion au serveur : " + ex.Message);
        }
    }
}
