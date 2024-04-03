using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using YourNamespace;

namespace ProjetBadgeBackEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClientHandler clientHandler = new TcpClientHandler();
            clientHandler.ConnectToAllOpenPort();

            Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
            Console.Read();
        }
    }
}
