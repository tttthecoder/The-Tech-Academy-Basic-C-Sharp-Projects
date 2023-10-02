using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class TwentyOneDealer : Dealer
    {
        private Hand _hand = new Hand();
        public bool Stay { get; set; }
        public bool isBusted { get; set; }
        public Hand hand { get { return _hand; } set { _hand = value; } }
    }
}
