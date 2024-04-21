using System.ComponentModel;
using System.Net.Sockets;
using System.Threading.Tasks;

public class MainFormViewModel : INotifyPropertyChanged
{
    private ServerConnector serverConnector;
    private DataSender dataSender;
    private TcpClient client;

    public MainFormViewModel()
    {
        serverConnector = new ServerConnector();
        dataSender = new DataSender();
    }

    public async Task ConnectToServerAsync(string serverIP, int serverPort)
    {
        try
        {
            client = await serverConnector.ConnectAsync(serverIP, serverPort);        
        }
        catch (Exception ex)
        {
            // Gérez les exceptions liées à la connexion
            throw new Exception("Erreur lors de la connexion au serveur : " + ex.Message);
        }
    }

    public async Task SendMessage(string data)
    {
        try
        {
            if (client != null && client.Connected)
            {
                // Utilisez client pour envoyer le message
                await dataSender.SendDataAsync(client, data);
            }
            else
            {
                // Gérez le cas où le client n'est pas connecté
                throw new Exception("Le client n'est pas connecté au serveur.");
            }
        }
        catch (Exception ex)
        {
            // Gérez les exceptions liées à l'envoi du message
            throw new Exception("Erreur lors de l'envoi du message : " + ex.Message);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
