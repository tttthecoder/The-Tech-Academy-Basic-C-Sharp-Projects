using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class TwentyOnePlayer : Player
    {
        public TwentyOnePlayer(string name, int beginningBalance, int numOfHands) : base(name, beginningBalance)
        {
            int beginningBalanceForEachHand = beginningBalance / numOfHands;
            for (int i = 0; i< numOfHands;i++)
            {
                Player player = new Player(name, beginningBalanceForEachHand);
                player.isActivePlaying = true;
                this._listOfHands.Add(player);
            }
        }
        private List<Player> _listOfHands = new List<Player>();
        public List<Player> listOfHands { get { return _listOfHands; } set { _listOfHands = value; } }
    }
}
