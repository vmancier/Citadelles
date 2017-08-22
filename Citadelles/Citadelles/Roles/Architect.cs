using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class Architect : Role
    {
        public Architect() : base(7, "Architecte")
        {

        }

        // Pioche 2 cartes et les met dans sa main
        public override void Effect()
        {
            Random rnd = new Random();
            int index = rnd.Next(Game.Library.Count);
            Game.GetRole(7).Hand.Add(Game.Library.ElementAt(index));
            Game.Library.RemoveAt(index);

            index = rnd.Next(Game.Library.Count);
            Game.GetRole(7).Hand.Add(Game.Library.ElementAt(index));
            Game.Library.RemoveAt(index);
        }
    }
}
