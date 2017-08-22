using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class Assassin : Role
    {

        public Assassin() : base(1, "Assassin")
        {
            
        }

        public override void Effect()
        {
            Console.WriteLine("Choisissez le role que vous voulez assassiner :");
            Console.WriteLine("2. Voleur");
            Console.WriteLine("3. Magicien");
            Console.WriteLine("4. Roi");
            Console.WriteLine("5. Evêque");
            Console.WriteLine("6. Marchand");
            Console.WriteLine("7. Architecte");
            Console.WriteLine("8. Condottière");

            List<string> roles = new List<string>();
            for(int i=2;i<9;i++)
            {
                roles.Add("NumPad" + i.ToString());
            }

            ConsoleKeyInfo crk;
            do
            {
                crk = Console.ReadKey();
            } while (!(roles.Contains(crk.Key.ToString())));

            int rank = int.Parse(crk.Key.ToString().Remove(0, 6));
            Game.GetRole(rank).Killed=true;

        }
    }
}
