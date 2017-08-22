using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class Thief : Role
    {
        public Thief() : base(2, "Voleur")
        {

        }

        // Vole les PO d'un role au début du tour du role en question
        public override void Effect()
        {
            // A Faire : récupérer le role assassinné

            Console.WriteLine("Choisissez le role que vous voulez voler :");
            Console.WriteLine("3. Magicien");
            Console.WriteLine("4. Roi");
            Console.WriteLine("5. Evêque");
            Console.WriteLine("6. Marchand");
            Console.WriteLine("7. Architecte");
            Console.WriteLine("8. Condottière");

            List<string> roles = new List<string>();
            for (int i = 3; i < 9; i++)
            {
                roles.Add("NumPad" + i.ToString());
            }

            ConsoleKeyInfo crk;
            do
            {
                crk = Console.ReadKey();
            } while (!(roles.Contains(crk.Key.ToString())));

            int rank = int.Parse(crk.Key.ToString().Remove(0, 6));
            Game.GetRole(rank).Stolen = true;
        }
    }
}
