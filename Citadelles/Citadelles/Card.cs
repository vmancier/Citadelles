using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citadelles.Roles;

namespace Citadelles
{
    public enum Colors {Blue, Red, Yellow, Green, Purple};
    class Card
    {
        private Colors _color;
        private int _cost;
        private string _name;

        public Colors Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }
        public int Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
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

        public Card(string name, int cost , Colors color)
        {
            Name = name;
            Cost = cost;
            Color = color;
        }

        public virtual void Effect()
        { 

        }

        public static Card Temple()
        {
            return new Card("Temple", 1, Colors.Blue);
        }
        public static Card Eglise()
        {
            return new Card("Eglise", 2, Colors.Blue);
        }
        public static Card Monastere()
        {
            return new Card("Monastère", 3, Colors.Blue);
        }
        public static Card Cathedrale()
        {
            return new Card("Cathédrale", 5, Colors.Blue);
        }
        public static Card Manoir()
        {
            return new Card("Manoir", 3, Colors.Yellow);
        }
        public static Card Chateau()
        {
            return new Card("Chateau", 4, Colors.Yellow);
        }
        public static Card Palais()
        {
            return new Card("Palais", 5, Colors.Yellow);
        }
        public static Card Taverne()
        {
            return new Card("Palais", 1, Colors.Yellow);
        }
        public static Card Echoppe()
        {
            return new Card("Echoppe", 2, Colors.Green);
        }
        public static Card Marche()
        {
            return new Card("Marché", 2, Colors.Green);
        }
        public static Card Comptoir()
        {
            return new Card("Comptoir", 3, Colors.Green);
        }
        public static Card Port()
        {
            return new Card("Port", 4, Colors.Green);
        }
        public static Card HotelDeVille()
        {
            return new Card("Hôtel de ville", 5, Colors.Green);
        }
        public static Card TourDeGuet()
        {
            return new Card("Tour de guet", 1, Colors.Red);
        }
        public static Card Prison()
        {
            return new Card("Prison", 2, Colors.Red);
        }
        public static Card Caserne()
        {
            return new Card("Caserne", 3, Colors.Red);
        }
        public static Card Forteresse()
        {
            return new Card("Forteresse", 5, Colors.Red);
        }

    }
}
