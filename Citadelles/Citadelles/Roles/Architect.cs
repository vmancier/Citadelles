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

        public override void Effect()
        {
            Game.GetRole(7).Draw(Game.Library);
            Game.GetRole(7).Draw(Game.Library);
        }
    }
}
