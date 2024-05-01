
public partial class MainForm : Form
{
    private MainFormViewModel _viewModel;
    private TextBox messageTextBox;   

    public MainForm()
    {
        InitializeComponent();
        _viewModel = new MainFormViewModel();              
    }

    private async void ConnectButton_Click(object sender, EventArgs e)
    {
        // Gérez l'événement Click du bouton de connexion
        try
        {
            await _viewModel.ConnectToServerAsync("127.0.0.1", 10116);
            
        }
        catch (Exception ex)
        {            
        }
    }

    private async void SendButton_Click(object sender, EventArgs e)
    {
        // Gérez l'événement Click du bouton d'envoi
        try
        {
            DictionnairePixel dictionnairePixel = new DictionnairePixel(); 
            string message = messageTextBox.Text;
            message = dictionnairePixel.translate(message).ToString();
            await _viewModel.SendMessage(message);
            MessageBox.Show("Message envoyé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            // Gérez les exceptions liées à l'envoi du message
            MessageBox.Show("Erreur lors de l'envoi du message : " + ex.Message, "Erreur d'envoi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitializeComponent()
    {  
        Button connectButton = new Button();
        connectButton.Text = "Connexion";
        connectButton.Click += ConnectButton_Click;
        this.Controls.Add(connectButton);

        messageTextBox = new TextBox();
        messageTextBox.Location = new Point(10, 50); 
        messageTextBox.Size = new Size(200, 20);
        this.Controls.Add(messageTextBox);

        Button sendButton = new Button();
        sendButton.Text = "Envoyer";
        sendButton.Location = new Point(10, 80);
        sendButton.Click += SendButton_Click;
        this.Controls.Add(sendButton);
    }
}