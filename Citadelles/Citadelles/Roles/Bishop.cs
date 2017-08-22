using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class Bishop : Role
    {
        public Bishop() : base(5, "Évêque")
        {

        }

        public override void Effect()
        {
            Player p =Game.GetRole(5);

            foreach(Card c in p.Board)
            {
                if(c.Color == Colors.Blue)
                {
                    p.Coins++;
                }
            }
        }
    }
}
