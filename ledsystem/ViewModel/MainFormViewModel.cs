using System.ComponentModel;
using System.Net.Sockets;
using System.Threading.Tasks;

public class MainFormViewModel : INotifyPropertyChanged
{
    private ServerConnector serverConnector;
    private DataSender dataSender;
    private List<TcpClient> _clients;

    public MainFormViewModel()
    {
        serverConnector = new ServerConnector();
        dataSender = new DataSender();
    }

    public async Task ConnectToServerAsync(string serverIP, int minPort, int maxPort)
    {
        try
        {
            ServerConnector tcpClientListCreator = new ServerConnector();
            _clients = tcpClientListCreator.CreateTcpClientList(serverIP, minPort, maxPort);
            
        }
        catch (Exception ex)
        {           
            throw new Exception("Erreur lors de la connexion au serveur : " + ex.Message);
        }
    }

    public async Task SendMessage(string data)
    {
        try
        {
            if (_clients != null && _clients.Any(client => client.Connected))
            {                
                await dataSender.SendDataAsync(_clients, data);
            }
            else
            {                
                throw new Exception("Le client n'est pas connecté au serveur.");
            }
        }
        catch (Exception ex)
        {            
            throw new Exception("Erreur lors de l'envoi du message : " + ex.Message);
        }
    }

    /*public async Task Disconnect()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }*/

    public event PropertyChangedEventHandler? PropertyChanged;
}
