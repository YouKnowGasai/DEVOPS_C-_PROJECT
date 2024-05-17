using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class DataSender
{
    public async Task SendDataAsync(List<TcpClient> clients, string data)
    {
        foreach (var client in clients)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'envoi des données : " + ex.Message);
            }
        }
    }
}
