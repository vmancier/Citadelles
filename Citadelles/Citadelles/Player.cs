﻿using Citadelles.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles
{
    public class Player
    {
        private static int _nbplayers = 0;

        private int _id;
        private int _coins;
        private List<Card> _hand;
        private List<Card> _board;
        private Role _role;
        private bool _crown;
        private bool _killed;
        private bool _stolen;
        private int _victoryPoints;

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
        public bool Killed
        {
            get
            {
                return _killed;
            }

            set
            {
                _killed = value;
            }
        }
        public bool Stolen
        {
            get
            {
                return _stolen;
            }

            set
            {
                _stolen = value;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public int VictoryPoints
        {
            get
            {
                return _victoryPoints;
            }

            set
            {
                _victoryPoints = value;
            }
        }


        public Player(bool crown)
        {
            Coins = 2;
            Hand = new List<Card>();
            Board = new List<Card>();
            Crown = crown;
            Killed = false;
            Stolen = false;
            _nbplayers++;
            _id = _nbplayers;
            _victoryPoints = 0;
        }


        // Le joueur pioche 2 cartes, en met 1 dans sa main et met l'autre sous la pioche
        public void Draw(List<Card> cards)
        {
            Console.Clear();
            Console.WriteLine(ToString());

            Random rnd = new Random();
            int index1 = rnd.Next(cards.Count);
            Card c1 = cards.ElementAt(index1);
            int index2 = rnd.Next(cards.Count);
            Card c2 = cards.ElementAt(index2);

            ConsoleKeyInfo crk;
            Console.WriteLine("Choisissez la carte que vous souhaitez garder :");
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            do
            {
                crk = Console.ReadKey();
            } while (!(new[] { "NumPad1", "NumPad2" }.Contains(crk.Key.ToString())));

            Console.Clear();
            if (crk.Key.ToString() == "NumPad1")
            {
                Hand.Add(cards.ElementAt(index1));
                cards.RemoveAt(index1);
            }
            else
            {
                Hand.Add(cards.ElementAt(index2));
                cards.RemoveAt(index2);
            }
            
        }

        // Le joueur chosit un des roles restant
        public void ChooseRole(List<Role> roles)
        {
            List<string> rolesRemaining = new List<string>();
            Console.WriteLine("*** Joueur "+_id+" ***");
            Console.WriteLine("Choisissez votre role :");
            //Affiche la liste des roles restants
            //et récupère la liste des rangs des roles restants
            foreach (Role role in roles)
            {
                Console.WriteLine(role);
                rolesRemaining.Add("NumPad"+role.Rank.ToString());
            }            

            ConsoleKeyInfo crk;
            do
            {
                crk = Console.ReadKey();
            } while (!(rolesRemaining.Contains(crk.Key.ToString())));

            // Le joueur prend la carte dans le tas de roles
            int rank = int.Parse(crk.Key.ToString().Remove(0,6));
            for (int i=0; i<roles.Count;i++)// A OPTIMISER AVEC UN WHILE
            {
                if(roles.ElementAt(i).Rank == rank)
                {
                    _role = roles.ElementAt(i);
                    roles.RemoveAt(i);
                }
            }

            Console.Clear();
        }

        //Tour de jeu du joueur
        public void Turn()
        {
            // Donne l'argent au voleur;
            if(Stolen)
            {
                foreach (Player p in Game.Players)
                {
                    if(p.Role.Rank == 2)
                    {
                        p.Coins += _coins;
                        _coins = 0;
                    }
                }
            }

            Console.WriteLine(ToString());
            _role.Effect();
            Console.Clear();

            // Le joueur choisir de piocher ou de prendre 2 PO
            Console.WriteLine(ToString());
            Console.WriteLine("Choisissez vous de :");
            Console.WriteLine("1. Piocher");
            Console.WriteLine("2. Prendre 2 PO");
            ConsoleKeyInfo crk;
            do
            {
                crk = Console.ReadKey();
            } while (!(new[] { "NumPad1", "NumPad2" }.Contains(crk.Key.ToString())));

            if(crk.Key.ToString()== "NumPad1")
            {
                Draw(Game.Library);
            }
            else
            {
                _coins += 2;
            }

            //Poser des cartes sur le board

            // Gagné ?
            if (Board.Count == Game.NbCardsOnBoard && !Game.Winner)
            {
                Game.Winner = true;
                _victoryPoints += 2;
            }

        }

        public override string ToString()
        {
            string text = "*** Joueur " + _id + " ***\n";
            text += _role.Name + "\n";
            text += "- PO : " + _coins + "\n";
            text += "-- Main --\n";
            foreach (Card c in _hand)
            {
                text += c.ToString() + "\n";
            }
            text += "-- Board --\n";
            foreach (Card c in _board)
            {
                text += c.ToString() + "\n";
            }
            return text;
        }

        public void WatchOtherPlayers()
        {

        }

    }
}
