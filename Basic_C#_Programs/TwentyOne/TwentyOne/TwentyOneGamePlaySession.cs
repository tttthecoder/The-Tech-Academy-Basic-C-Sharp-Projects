using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TwentyOne
{
    //This class is for creating the model in our database. The object of this class is meant to represent a particular play session of 21 game.
    //in a session, we have specific cards for each hand of the player and the lose-or-win-status for each hand is observed.
    public class TwentyOneGamePlaySession
    {
        [Key]
        public int SessionId { get; set; }
        public string PlayerName { get; set; }
        public string HandOne { get; set; }
        public bool? HandOneLostStatus { get; set; }
        public int HandOneBet { get; set; }
        public string HandTwo { get; set; }
        public bool? HandTwoLostStatus { get; set; }
        public int HandTwoBet { get; set; }
        public string HandThree { get; set; }
        public bool? HandThreeLostStatus { get; set; }
        public int HandThreeBet { get; set; }
        public string DealerHand { get; set; }

    }
}
