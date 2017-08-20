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
        private List<Card> _library;
        private List<Player> _players;
        private List<Role> _roles;
        private int _nbPlayers;

        public Game(int nbPlayers)
        {
            _nbPlayers = nbPlayers;
            _roles = new List<Role>();

            Init();
            Play();

            Console.Read();
        }

        //Initialise la partie
        public void Init()
        {
            LoadLibrary();

            //Création des joueurs
            _players = new List<Player>();
            _players.Add(new Player(true));//Assignation de la couronne au premier tour
            for (int i = 1; i < _nbPlayers; i++)
            {
                _players.Add(new Player(false));
            }

            //Distribution des cartes
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < _nbPlayers; j++)
                {
                    _players.ElementAt(j).Draw(_library);
                }
            }

        }

        //Initialise le paquet de cartes
        public void LoadLibrary()
        {
            _library = new List<Card>();

            //Cartes Bleues
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Temple());
            }
            for (int i = 0; i < 4; i++)
            {
                _library.Add(Card.Eglise());
            }
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Monastere());
            }
            for (int i = 0; i < 2; i++)
            {
                _library.Add(Card.Cathedrale());
            }

            //Cartes Jaunes
            for (int i = 0; i < 5; i++)
            {
                _library.Add(Card.Manoir());
            }
            for (int i = 0; i < 4; i++)
            {
                _library.Add(Card.Chateau());
            }
            for (int i = 0; i < 2; i++)
            {
                _library.Add(Card.Palais());
            }

            //Cartes Vertes
            for (int i = 0; i < 5; i++)
            {
                _library.Add(Card.Taverne());
            }
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Echoppe());
            }
            for (int i = 0; i < 4; i++)
            {
                _library.Add(Card.Marche());
            }
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Comptoir());
            }
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Port());
            }
            for (int i = 0; i < 2; i++)
            {
                _library.Add(Card.HotelDeVille());
            }

            //Cartes Rouges
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.TourDeGuet());
            }
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Prison());
            }
            for (int i = 0; i < 3; i++)
            {
                _library.Add(Card.Caserne());
            }
            for (int i = 0; i < 2; i++)
            {
                _library.Add(Card.Forteresse());
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


            }
            while(PlayingGame());
        }

        //Initialise les roles au début du tour 
        public void LoadRoles()
        {
            _roles.Clear();
            _roles.Add(new Assassin());
            _roles.Add(new Thief());
            _roles.Add(new Magician());
            _roles.Add(new King());
            _roles.Add(new Bishop());
            _roles.Add(new Merchant());
            _roles.Add(new Architect());
            _roles.Add(new Warlord());
        }

        //Vérifie les conditions de victoire
        public bool PlayingGame()
        {
            // A faire
            // Vérifier si la Merveille qui permet de gagner en 7 tours est présente

            int nbCardsOnBoard = 8;

            foreach(Player player in _players)
            {
                if(player.Board.Count == nbCardsOnBoard)
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
            int index = rnd.Next(_roles.Count);
            _roles.RemoveAt(index);
        }

        //Cherche l'index du joueur avec la couronne
        public int GetCrown()
        {
            int crownIndex = 0;
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players.ElementAt(i).Crown)
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

            for (int i = crownIndex; i < _players.Count; i++)
            {
                _players.ElementAt(i).ChooseRole();

            }

            for (int i = 0; i < crownIndex; i++)
            {
                _players.ElementAt(i).ChooseRole();
            }
        }

    }
}
