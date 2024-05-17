using System.Net;

public partial class MainForm : Form
{
    private MainFormViewModel _viewModel;
    private TextBox messageTextBox;
    private TextBox ipAddressTextBox;
    private TextBox portMinTextBox;
    private TextBox portMaxTextBox; 

    public MainForm()
    {
        InitializeComponent();
        _viewModel = new MainFormViewModel();              
    }

    private async void ConnectButton_Click(object sender, EventArgs e)
    {
        try
        {
            string ipAddress = ipAddressTextBox.Text;
            int portMin;
            int portMax;

            if (!IPAddress.TryParse(ipAddress, out _))
            {
                MessageBox.Show("Adresse IP invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!int.TryParse(portMinTextBox.Text, out portMin) || !int.TryParse(portMaxTextBox.Text, out portMax) || portMin < 1 || portMax > 65535)
            {
                MessageBox.Show("Port invalide. Veuillez entrer un port entre 1 et 65535.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await _viewModel.ConnectToServerAsync(ipAddress, portMin, portMax);
            
        }
        catch (Exception ex)
        {            
        }
    }

    private async void DisconnectButton_Click(object sender, EventArgs e)
    {
        //await _viewModel.Disconnect();
    }

    private async void SendButton_Click(object sender, EventArgs e)
    {
        try
        {
            string message = messageTextBox.Text;
            await _viewModel.SendMessage(message);            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erreur lors de l'envoi du message : " + ex.Message, "Erreur d'envoi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitializeComponent()
    {  
        Label infoLabel = new Label();
        infoLabel.Location = new Point(10, 110); 
        infoLabel.Size = new Size(200, 20); 
        infoLabel.Text = "Information"; 
        this.Controls.Add(infoLabel);

        Button connectButton = new Button();
        connectButton.Location = new Point(25, 25);
        connectButton.Text = "Connexion";
        connectButton.Click += ConnectButton_Click;
        this.Controls.Add(connectButton);

        Button disconnectButton = new Button();
        disconnectButton.Location = new Point(100, 25);
        disconnectButton.Text = "Déconnexion";
        disconnectButton.Click += DisconnectButton_Click;
        this.Controls.Add(disconnectButton);

        messageTextBox = new TextBox();
        messageTextBox.Location = new Point(10, 50); 
        messageTextBox.Size = new Size(200, 20);
        this.Controls.Add(messageTextBox);

        Button sendButton = new Button();
        sendButton.Text = "Envoyer";
        sendButton.Location = new Point(10, 80);
        sendButton.Click += SendButton_Click;        
        this.Controls.Add(sendButton);

        ipAddressTextBox = new TextBox();
        ipAddressTextBox.Location = new Point(10, 140); 
        ipAddressTextBox.Size = new Size(200, 20);
        ipAddressTextBox.PlaceholderText = "Adresse IP";        
        this.Controls.Add(ipAddressTextBox);

        portMinTextBox = new TextBox();
        portMinTextBox.Location = new Point(10, 170); 
        portMinTextBox.Size = new Size(50, 20);
        portMinTextBox.PlaceholderText = "PortMin";        
        this.Controls.Add(portMinTextBox);

        portMaxTextBox = new TextBox();
        portMaxTextBox.Location = new Point(100, 170); 
        portMaxTextBox.Size = new Size(50, 20);
        portMaxTextBox.PlaceholderText = "PortMax";        
        this.Controls.Add(portMaxTextBox);
    }
}