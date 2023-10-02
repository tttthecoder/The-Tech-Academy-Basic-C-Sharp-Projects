using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class TwentyOneGame : Game, IWalkAway
    {
        public TwentyOneDealer Dealer { get; set; }
        public override void Play()
        {

            Console.WriteLine("-----------Game starts!-------------------");
            //initialize a player and their hands.
            Player player = this.Players.First();
            Console.WriteLine("How many hands would you like to play?");
            int numOfHands = Convert.ToInt32(Console.ReadLine());
            player.numOfHands = numOfHands;
            player.handsAndBets = new Dictionary<TwentyOnePlayerHand, int>();
            //initialize a dealer.
            Dealer = new TwentyOneDealer();
            Dealer.hand = new Hand();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle();
            for (int i = 0; i < player.numOfHands; i++)
            {
                TwentyOnePlayerHand hand = new TwentyOnePlayerHand();
                hand.Lost = null;
                hand.handName = "Hand " + (i + 1);
                Console.WriteLine("Place your bet for {0}", hand.handName);
                string reply = Console.ReadLine();
                int bet = Convert.ToInt32(reply);
                while (!player.Bet(bet))
                {
                    bet = Convert.ToInt32(Console.ReadLine());
                }
                Bets[hand] = bet;
                player.handsAndBets[hand] = bet;
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing..");
                foreach (TwentyOnePlayerHand hand in player.handsAndBets.Keys)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(hand);
                    Console.WriteLine(hand.Cards.Last().ToString() + "\n");
                }
                Dealer.Deal(Dealer.hand);


            }
            //Dealing with each hand of player.
            foreach (TwentyOnePlayerHand hand in player.handsAndBets.Keys)
            {
                bool blackJack = TwentyOneRules.checkForBlackJack(hand.Cards);
                if (blackJack)
                {

                    Console.WriteLine("Blackjack! {0} wins {1}", hand.handName, Bets[hand]*1.5);
                    hand.Lost = false;
                    player.Balance += Convert.ToInt32(1.5m * Bets[hand] + Bets[hand]);
                    Console.WriteLine("Your balance now is {0}", player.Balance);
                    hand.Stay = true;
                    Bets.Remove(hand);
                }
                else
                {
                    while (!hand.Stay)
                    {
                        hand.showCards();
                        Console.WriteLine("\n\nHit or Stay?");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "stay")
                        {
                            hand.Stay = true;
                            break;
                        }
                        else if (answer == "hit")
                        {
                            Dealer.Deal(hand);
                            Console.WriteLine("You just got the {0} of {1} for {2}.", hand.Cards.Last().Face, hand.Cards.Last().Suit, hand.handName);
                        }
                        bool busted = TwentyOneRules.isBusted(hand.Cards);
                        if (busted)
                        {
                            hand.Lost = true;
                            Dealer.Balance += Bets[hand];
                            Console.WriteLine("{0} Busted! you lose your bet of {1}", hand.handName, Bets[hand]);
                            Console.WriteLine("Your balance now is {0}", player.Balance);
                            Bets.Remove(hand);
                            break;
                        }

                        if (hand.Cards.Count == 5)
                        {
                            hand.Lost = false;
                            Console.WriteLine("Player won!");
                            Console.WriteLine("{0} won {1}!", hand.handName, Bets[hand]);
                            player.Balance += 2 * Bets[hand];
                            Dealer.Balance -= Bets[hand];
                            Console.WriteLine("Your balance now is {0}", player.Balance);
                            Bets.Remove(hand);
                            break;
                        }
                    }
                }
                Console.WriteLine("{0} is locked", hand.handName);

            }
            List<TwentyOnePlayerHand> undeterminedHands = player.handsAndBets.Keys.ToList().Where(x => x.Lost == null).ToList();
            if (undeterminedHands.Count == 0)
            {
                return;
            }

            Dealer.isBusted = TwentyOneRules.isBusted(Dealer.hand.Cards);
            Dealer.Stay = TwentyOneRules.shouldDealerStay(Dealer.hand.Cards);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.hand);
                Dealer.isBusted = TwentyOneRules.isBusted(Dealer.hand.Cards);
                Dealer.Stay = TwentyOneRules.shouldDealerStay(Dealer.hand.Cards);
            }
            //Check if dealer is busted.
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer busted!");
                foreach (TwentyOnePlayerHand hand in undeterminedHands)
                {
                    Console.WriteLine("{0} won {1}!", hand.handName, Bets[hand]);
                    player.Balance += 2 * Bets[hand];
                    Dealer.Balance -= Bets[hand];
                }
                return;
            }

            Console.WriteLine("Dealer is staying");

            foreach (TwentyOnePlayerHand hand in undeterminedHands)
            {
                Console.WriteLine("dealing with {0}",hand.handName);
                bool? handWon = TwentyOneRules.CompareHands(hand.Cards, Dealer.hand.Cards);
                if (handWon == null)
                {
                    Console.WriteLine("Push! no one wins.");
                    player.Balance += Bets[hand];
                    Bets.Remove(hand);
                }
                else if (handWon == true)
                {
                    Console.WriteLine("{0} won {1}!", hand.handName, Bets[hand]);
                    player.Balance += 2 * Bets[hand];
                    Dealer.Balance -= Bets[hand];

                }
                else
                {
                    Console.WriteLine("Dealer won {0}!", hand.handName);
                    Dealer.Balance += Bets[hand];
                }
                Console.WriteLine("Your balance now is {0}", player.Balance);
            }
            Console.WriteLine("Dealer cards are: ");
            foreach (Card card in Dealer.hand.Cards)
            {
                Console.WriteLine("{0} ", card.ToString());
            }
            return;
        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 players: ");
            base.ListPlayers();
        }
        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
        public override void askIfUserWantToPlayAgain(Player player)
        {
            if (player.Balance <= 0)
            {
                Console.WriteLine("Sorry, your balance is not enough to continue to play.");
                return;
            }
            Console.WriteLine("\nPlay again?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah")
            {
                player.isActivePlaying = true;
            }
            else
            {
                player.isActivePlaying = false;
            }
        }
    }
}




