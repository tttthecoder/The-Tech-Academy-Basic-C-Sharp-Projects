using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public abstract class Game
    {
        private List<Player> _Players = new List<Player>();
        private Dictionary<Hand, int> _bets = new Dictionary<Hand, int>();
        public List<Player> Players { get { return _Players; } set { _Players = value; }}
        public string Name { get; set; }
        public Dealer Dealer { get; set; }
        public Dictionary<Hand, int> Bets { get { return _bets; } set { _bets = value; } }

        public abstract void Play();
        public virtual void ListPlayers()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
        public abstract void askIfUserWantToPlayAgain(Player player); 
    }
}
