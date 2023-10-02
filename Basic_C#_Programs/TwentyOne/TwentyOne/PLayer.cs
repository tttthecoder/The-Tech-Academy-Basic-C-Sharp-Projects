using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Player
    {
        public Player(string name, int beginningBalance)
        {
            //this.Hand = new List<Card>();
            this.Name = name;
            this.Balance = beginningBalance;
        }

        private Dictionary<TwentyOnePlayerHand, int> _handsAndBets = new Dictionary<TwentyOnePlayerHand, int>();
        public Dictionary<TwentyOnePlayerHand, int> handsAndBets { get { return _handsAndBets; } set { _handsAndBets = value; } }
        public int numOfHands { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivePlaying { get; set; }


        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size. Please put a lower bet!");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

        public static Game operator +(Game game, Player player)
        {
            game.Players.Add(player);
            return game;
        }
        public static Game operator -(Game game, Player player)
        {
            game.Players.Remove(player);
            return game;
        }

    }

    public class TwentyOnePlayerHand : Hand
    {
        public bool Stay { get; set; }
        public bool? Lost { get; set; }
        public string handName { get; set; }
        //public int Bet { get; set; }
        public void showCards()
        {
            Console.WriteLine("{0} cards are: ", this.handName);
            foreach (Card card in this.Cards)
            {
                Console.WriteLine("{0} of {1}", card.Face, card.Suit);
            }
        }
    }
}
