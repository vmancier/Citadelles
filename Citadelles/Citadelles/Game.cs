using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadelles
{
    public enum States { PLAYING, FINISH };

    public class Game
    {
        private List<Card> _library;
        private List<Player> _players;
        private States _state;

        public Game()
        {
            Init(5);
            //créer les cartes et les mettres dans la librairy
            //Créer les joueurs
            //Distribuer les cartes d
        }

        //Initialise la partie
        public void Init(int nbPlayers)
        {
            LoadLibrary();

            //Création des joueurs
            _players = new List<Player>();
            for (int i = 0; i < nbPlayers; i++)
            {
                _players.Add(new Player());
            }

            //Distribution des cartes
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < nbPlayers; j++)
                {
                    _players.ElementAt(j).Draw(_library);
                }
            }

            Console.WriteLine(_players.ElementAt(4).Hand.Count);
            Console.Read();
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
    }
}
