using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class Merchant : Role
    {
        public Merchant() : base(6, "Marchand")
        {

        }

        public override void Effect()
        {
            Player p = Game.GetRole(6);

            foreach (Card c in p.Board)
            {
                if (c.Color == Colors.Green)
                {
                    p.Coins++;
                }
            }

            p.Coins++;
        }
    }
}
