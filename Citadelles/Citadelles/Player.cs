using Citadelles.Roles;
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
        private bool _crown;

        public int Coins
        {
            get
            {
                return _coins;
            }

            set
            {
                _coins = value;
            }
        }
        internal List<Card> Hand
        {
            get
            {
                return _hand;
            }

            set
            {
                _hand = value;
            }
        }
        internal List<Card> Board
        {
            get
            {
                return _board;
            }

            set
            {
                _board = value;
            }
        }
        public bool Crown
        {
            get
            {
                return _crown;
            }

            set
            {
                _crown = value;
            }
        }
        internal Role Role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }

        public Player(bool crown)
        {
            Coins = 2;
            Hand = new List<Card>();
            Board = new List<Card>();
            Crown = crown;
        }

        // A Modifier !
        // prend une carte au hasard et la met dans la main
        // Mais :  Doit prendre 2 cartes, en choisir 1 et mettre l'autre sous la pioche
        public void Draw(List<Card> cards)
        {
            Random rnd = new Random();
            int index = rnd.Next(cards.Count);
            _hand.Add(cards.ElementAt(index));
            cards.RemoveAt(index);
        }

        // Le joueur chosit un des roles restant
        public void ChooseRole()
        {

        }

        //Tour de jeu du joueur
        public void Turn()
        {

        }


    }
}
