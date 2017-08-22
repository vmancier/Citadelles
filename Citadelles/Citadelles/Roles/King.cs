using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class King : Role
    {
        public King() : base(4, "Roi")
        {

        }

        public override void Effect()
        {
            Player p = Game.GetRole(4);

            foreach (Card c in p.Board)
            {
                if (c.Color == Colors.Yellow)
                {
                    p.Coins++;
                }
            }
        }
    }
}
