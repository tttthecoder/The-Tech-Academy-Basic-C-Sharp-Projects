using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }
        public void Deal(List<Card> Hand)
        {

            Hand.Add(Deck.Cards.First());
            //Console.WriteLine(Deck.Cards.First().ToString() + "\n");//have to hide this line as I want to hide dealer hand from user. 
            Deck.Cards.RemoveAt(0);
        }


    }
}
