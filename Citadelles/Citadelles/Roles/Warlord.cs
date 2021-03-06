﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles.Roles
{
    public class Warlord : Role
    {
        public Warlord() : base(8, "Condottière")
        {

        }

        // Les quartiers RED sur son Board lui rapportent 1 PO
        // Détruit un quartier
        public override void Effect()
        {
            Player p = Game.GetRole(8);

            foreach (Card c in p.Board)
            {
                if (c.Color == Colors.Red)
                {
                    p.Coins++;
                }
            }
        }
    }
}
