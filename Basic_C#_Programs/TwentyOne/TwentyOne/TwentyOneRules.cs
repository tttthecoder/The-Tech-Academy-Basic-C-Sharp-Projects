using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public abstract class TwentyOneRules
    {

        private static Dictionary<Face, Int32> _cardValues = new Dictionary<Face, Int32>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1,
        };


        public static int[] getAllPossibleHandValues(List<Card> Hand)
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace);
            int[] result = new int[aceCount + 1];
            int value = Hand.Sum(x => _cardValues[x.Face]);
            result[0] = value;
            if (result.Length == 1) return result;
            for (int i = 1; i < result.Length; i++)
            {
                value += 10;
                //value += (i*10) ; //instructor version.
                result[i] = value;

            }
            return result;
        }
        public static bool checkForBlackJack(List<Card> Hand)
        {
            int[] possibleValues = getAllPossibleHandValues(Hand);
            int value = possibleValues.Max();

            if (value >= 21) return true;
            //if (value == 21) return true; //instructor version.
            else return false;
        }
        public static bool isBusted(List<Card> Hand)
        {
            int value = getAllPossibleHandValues(Hand).Min();
            if (value > 21)
            {
                return true;
            }
            //else return false; // instructor version. 
            return false;
        }
        public static bool shouldDealerStay(List<Card> hand)
        {
            int[] possibleHandValues = getAllPossibleHandValues(hand);
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool? CompareHands(List<Card> playerHand, List<Card> dealerHand)
        {
            int[] playerResults = getAllPossibleHandValues(playerHand);
            int[] dealerResults = getAllPossibleHandValues(dealerHand);
            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResults.Where(x => x < 22).Max();
            
            if (playerScore > dealerScore)
            {
                return true;
            }
            else if (playerScore < dealerScore){
                return false;
            }
            else
            {
                return null;
            }



        }

    }

}
