using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace YourNamespace
{
    public class TcpClientHandler
    {
        private string server = "127.0.0.1";
        private int startPort = 13011;
        private int endPort = 13011;
        private string message = "Bonjour, serveur!";
        public void ConnectToAllOpenPort()
        {
            for (int port = startPort; port <= endPort; port++)
            {
                if (TestOpenPort(port))
                {
                    try
                    {
                        TcpClient client = new TcpClient(server, port);
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                        Console.WriteLine("Message envoyé: {0}", message);

                        //data = new byte[256];
                        //string responseData = String.Empty;
                        //int bytes = stream.Read(data, 0, data.Length);
                        //responseData = Encoding.ASCII.GetString(data, 0, bytes);
                        //Console.WriteLine("Réponse reçue: {0}", responseData);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erreur lors de la connexion au port {0}: {1}", port, e.Message);
                    }
                }
            }
        }

        private static bool TestOpenPort(int port)
        {
            var tcpListener = default(TcpListener);

            try
            {
                var ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
                tcpListener = new TcpListener(ipAddress, port);
                tcpListener.Start();
                return true;
            }
            catch (SocketException)
            {
            }
            finally
            {
                if (tcpListener != null)
                    tcpListener.Stop();
            }

            return false;
        }
    }
}
