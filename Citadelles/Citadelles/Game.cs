using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citadelles.Roles;

namespace Citadelles
{
    public enum States { PLAYING, FINISH };

    public class Game
    {
        private List<Card> _library;
        private List<Player> _players;
        private States _state;
        private int _nbPlayers;

        public Game(int nbPlayers)
        {
            _nbPlayers = nbPlayers;
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
        public void Play(){

        }
    }
}
