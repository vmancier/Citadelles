using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //crk.Key != ConsoleKey.NumPad1
            ConsoleKeyInfo crk;
            Console.WriteLine("Choisissez votre mode de jeu :");
            Console.WriteLine("1. Multiplayer (Tous les joueurs sont joués par des humains)");
            Console.WriteLine("2. 1 Joueur vs IA");
            Console.WriteLine("3. IA only (avec statistiques à la fin)");
            do
            {
                crk = Console.ReadKey();
            } while (!(new[] { "NumPad1", "NumPad2", "NumPad3"}.Contains(crk.Key.ToString())));

            Console.Clear();
            Console.WriteLine("Mode de jeu choisi");
            */

            Game game = new Game(6);

            Console.ReadLine();
        }
    }
}
