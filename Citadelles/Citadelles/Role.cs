using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles
{
    public abstract class Role
    {
        private int _rank;
        private string _name;

        public int Rank
        {
            get
            {
                return _rank;
            }

            set
            {
                _rank = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Role(int rank, string name)
        {
            Rank = rank;
            Name = name;
        }

        public abstract void Effect();

        public override string ToString()
        {
            string text = _rank+". "+ _name;
            return text;
        }

    }
}