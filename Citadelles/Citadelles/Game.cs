using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citadelles.Roles;

namespace Citadelles
{
    public class Game
    {
        private static List<Card> _library;
        private static List<Player> _players;
        private static List<Role> _roles;
        private int _nbPlayers;
        private static bool _winner;
        private static int _nbCardsOnBoard;

        public static List<Card> Library
        {
            get
            {
                return _library;
            }

            set
            {
                _library = value;
            }
        }
        public static List<Player> Players
        {
            get
            {
                return _players;
            }

            set
            {
                _players = value;
            }
        }
        public static List<Role> Roles
        {
            get
            {
                return _roles;
            }

            set
            {
                _roles = value;
            }
        }
        public static bool Winner
        {
            get
            {
                return _winner;
            }

            set
            {
                _winner = value;
            }
        }
        public static int NbCardsOnBoard
        {
            get
            {
                return _nbCardsOnBoard;
            }

            set
            {
                _nbCardsOnBoard = value;
            }
        }

        public Game(int nbPlayers)
        {
            _nbPlayers = nbPlayers;
            _winner = false;
            NbCardsOnBoard = 8;
            Roles = new List<Role>();

            Init();
            Play();

            Console.Read();
        }

        //Initialise la partie
        public void Init()
        {
            LoadLibrary();

            //Création des joueurs
            Players = new List<Player>();
            Players.Add(new Player(true));//Assignation de la couronne au premier tour
            for (int i = 1; i < _nbPlayers; i++)
            {
                Players.Add(new Player(false));
            }

            //Distribution des cartes
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < _nbPlayers; j++)
                {
                    int index = rnd.Next(Library.Count);
                    Players.ElementAt(j).Hand.Add(Library.ElementAt(index));
                    Library.RemoveAt(index);
                }
            }

        }

        //Initialise le paquet de cartes
        public void LoadLibrary()
        {
            Library = new List<Card>();

            //Cartes Bleues
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Temple());
            }
            for (int i = 0; i < 4; i++)
            {
                Library.Add(Card.Eglise());
            }
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Monastere());
            }
            for (int i = 0; i < 2; i++)
            {
                Library.Add(Card.Cathedrale());
            }

            //Cartes Jaunes
            for (int i = 0; i < 5; i++)
            {
                Library.Add(Card.Manoir());
            }
            for (int i = 0; i < 4; i++)
            {
                Library.Add(Card.Chateau());
            }
            for (int i = 0; i < 2; i++)
            {
                Library.Add(Card.Palais());
            }

            //Cartes Vertes
            for (int i = 0; i < 5; i++)
            {
                Library.Add(Card.Taverne());
            }
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Echoppe());
            }
            for (int i = 0; i < 4; i++)
            {
                Library.Add(Card.Marche());
            }
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Comptoir());
            }
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Port());
            }
            for (int i = 0; i < 2; i++)
            {
                Library.Add(Card.HotelDeVille());
            }

            //Cartes Rouges
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.TourDeGuet());
            }
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Prison());
            }
            for (int i = 0; i < 3; i++)
            {
                Library.Add(Card.Caserne());
            }
            for (int i = 0; i < 2; i++)
            {
                Library.Add(Card.Forteresse());
            }

            //Merveilles
            // A lister

        }

        //Fontion de jeu
        public void Play()
        {
            do
            {
                LoadRoles();
                BanRole();
                DraftRoles();

                //Les joueurs jouent selon l'ordre des roles
                for (int i = 1; i < 9; i++)
                {
                    Player p = GetRole(i);
                    if (p != null && !p.Killed)
                    {
                        p.Turn();
                    }
                    
                }

                //Tranfert de couronne
                Player king = GetRole(4);
                if (king != null)
                {
                    _players.ElementAt(GetCrown()).Crown = false;
                    king.Crown = true;
                }

                Console.Clear();
            }
            while(PlayingGame());

            LeaderBoards();
        }

        //Initialise les roles au début du tour 
        public void LoadRoles()
        {
            Roles.Clear();
            foreach (Player player in Players)
            {
                player.Role = null;
                player.Killed = false;
                player.Stolen = false;
            }

            Roles.Add(new Assassin());
            Roles.Add(new Thief());
            Roles.Add(new Magician());
            Roles.Add(new King());
            Roles.Add(new Bishop());
            Roles.Add(new Merchant());
            Roles.Add(new Architect());
            Roles.Add(new Warlord());
        }

        //Vérifie les conditions de victoire
        public bool PlayingGame()
        {
            // A faire
            // Vérifier si la Merveille qui permet de gagner en 7 tours est présente

            foreach(Player player in Players)
            {
                if(player.Board.Count == _nbCardsOnBoard)
                {
                    return false;
                }
            }

            return true;
        }

        //Ban  un role du jeu pour ce tour
        public void BanRole()
        {
            Random rnd = new Random();
            int index = rnd.Next(Roles.Count);
            Roles.RemoveAt(index);
        }

        //Cherche l'index du joueur avec la couronne
        public int GetCrown()
        {
            int crownIndex = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players.ElementAt(i).Crown)
                {
                    crownIndex = i;
                }
            }
            return crownIndex;

        }

        //Les joueurs choisissent un role en commençant par celui qui a la couronne
        public void DraftRoles()
        {
            int crownIndex = GetCrown();

            for (int i = crownIndex; i < Players.Count; i++)
            {
                Players.ElementAt(i).ChooseRole(Roles);

            }

            for (int i = 0; i < crownIndex; i++)
            {
                Players.ElementAt(i).ChooseRole(Roles);
            }
        }

        //Récupère le joueur avec le role correspondant
        public static Player GetRole(int rankRole)
        {
            foreach(Player player in Players)
            {
                if(player.Role.Rank== rankRole)
                {
                    return player;
                }
            }
            return null;
        }

        // Affiche le classement des scores des joueurs à la fin de la partie
        public void LeaderBoards()
        {
            // Calcul des points de victoires
            foreach(Player p in Players)
            {
                if(p.Board.Count == _nbCardsOnBoard)
                {
                    p.VictoryPoints += 2;
                }

                // OPTIMISABLE
                //Vérifie que le joueur possède des quartiers des cinq couleurs différentes
                bool red = false;
                bool green = false;
                bool yellow = false;
                bool blue = false;
                bool purple = false;
                foreach (Card c in p.Board)
                {
                    p.VictoryPoints += c.Cost;// Le joueur gagne les points de la carte

                    switch (c.Color)
                    {
                        case Colors.Red:
                            red = true;
                            break;
                        case Colors.Green:
                            green = true;
                            break;
                        case Colors.Yellow:
                            yellow = true;
                            break;
                        case Colors.Blue:
                            blue = true;
                            break;
                        case Colors.Purple:
                            purple = true;
                            break;
                    }
                }

                if(red && green && yellow && blue && purple)
                {
                    p.VictoryPoints += 3;
                }

                //Merveilles : Université et Dracoport +2 VictoryPoints
            }

            // Tri des joueurs par points de victoires
            List<Player> SortedList = Players.OrderByDescending(o => o.VictoryPoints).ToList();

            int i = 1;
            foreach (Player p in SortedList)
            {
                Console.WriteLine(i+ ".  Joueur " + p.Id + " : "+p.VictoryPoints+" points");
                i++;
            }

        }

    }
}
