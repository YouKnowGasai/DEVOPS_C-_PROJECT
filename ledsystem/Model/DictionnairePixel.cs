using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

public class DictionnairePixel
{

    public Dictionary<string, string> lettrePixel;

    public DictionnairePixel()
    {

    lettrePixel = new Dictionary<string, string>();

    lettrePixel.Add("A", "0000000000000000011001001011110100101001000000000000000");
    lettrePixel.Add("B", "0000000000000000111001001011100100101110000000000000000");
    lettrePixel.Add("C", "0000000000000000011101000010000100000111000000000000000");
    lettrePixel.Add("D", "0000000000000000111001001010010100101110000000000000000");
    lettrePixel.Add("E", "0000000000000000111101000011100100001111000000000000000");
    lettrePixel.Add("F", "0000000000000000111101000011100100001000000000000000000");
    lettrePixel.Add("G", "0000000000000000011101000010110100100111000000000000000");
    lettrePixel.Add("H", "0000000000000000100101001011110100101001000000000000000");
    lettrePixel.Add("I", "0000000000000000100001000010000100001000000000000000000");
    lettrePixel.Add("J", "0000000000000000000100001000010100100110000000000000000");
    lettrePixel.Add("K", "0000000000000000100101010011000101001001000000000000000");
    lettrePixel.Add("L", "0000000000000000100001000010000100001110000000000000000");
    lettrePixel.Add("M", "0000000000000001000111011101011000110001000000000000000");
    lettrePixel.Add("N", "0000000000000000100101101010110100101001000000000000000");
    lettrePixel.Add("O", "0000000000000000011001001010010100100110000000000000000");
    lettrePixel.Add("P", "0000000000000000111001001011100100001000000000000000000");
    lettrePixel.Add("Q", "0000000000000000011001001010010101100111000000000000000");
    lettrePixel.Add("R", "0000000000000000111001001011100101001001000000000000000");
    lettrePixel.Add("S", "0000000000000000011101000001100000101110000000000000000");
    lettrePixel.Add("T", "0000000000000000111000100001000010000100000000000000000");
    lettrePixel.Add("U", "0000000000000000100101001010010100101111000000000000000");
    lettrePixel.Add("V", "0000000000000000101001010010100101000100000000000000000");
    lettrePixel.Add("W", "0000000000000001000110001100011010101010000000000000000");
    lettrePixel.Add("X", "0000000000000000101001010001000101001010000000000000000");
    lettrePixel.Add("Y", "0000000000000000101001010011100010000100000000000000000");
    lettrePixel.Add("Z", "0000000000000000111100001000100010001111000000000000000");
    

    }

    public StringBuilder translate(String message){

        int compteur = 1;
        StringBuilder reponse = new StringBuilder();
        string debug;
        int debut = 0;
        int longueur = 5;

        for (int i = 1; i < 11; i++) {

                foreach (char lettre in message){

                    debug = lettrePixel[lettre.ToString()].Substring(debut,longueur);

                    reponse.Append(lettrePixel[lettre.ToString()].Substring(debut,longueur));

                }

                while (reponse.Length < 44 * compteur){
                    reponse.Append("0");
                }

                compteur++;
                debut += 5;
        
        }          


        return reponse;
    }

}

