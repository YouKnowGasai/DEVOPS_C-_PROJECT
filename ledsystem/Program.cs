using System;
using System.Windows.Forms;

public class Program
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Créez et lancez votre formulaire principal
        Application.Run(new MainForm());
    }
}
