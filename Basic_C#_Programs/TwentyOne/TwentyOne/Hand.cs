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
        

    }
}
