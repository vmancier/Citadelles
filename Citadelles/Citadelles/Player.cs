using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles
{
    class Player
    {
        private int _coins;
        private List<Card> _hand;
        private List<Card> _board;
        private Role _role;

        public Player(int coins)
        {
            _coins = coins;
        }
    }
}
