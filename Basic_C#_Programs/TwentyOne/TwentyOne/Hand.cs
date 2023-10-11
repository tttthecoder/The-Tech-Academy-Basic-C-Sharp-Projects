using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Hand
    {
        private List<Card> _Cards = new List<Card>();
        public List<Card> Cards { get { return _Cards; } set { _Cards = value; } }

        public override string ToString()
        {
            string result = "";
            foreach (Card card in this.Cards)
            {
                result += (card.ToString() + " ");
            }

            return result;
        }
    }
}
