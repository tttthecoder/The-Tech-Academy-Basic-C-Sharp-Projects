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
            Dealer = new TwentyOneDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle();
            Console.WriteLine("Place your bet!");

            foreach (Player player in Players)
            {
                int bet = Convert.ToInt32(Console.ReadLine());
                if (!player.Bet(bet))
                {
                    return;
                }
                Bets[player] = bet;
            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing..");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);
                    Console.WriteLine(player.Hand.Last().ToString() + "\n");
                    if (i == 1)
                    {
                        bool blackJack = TwentyOneRules.checkForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32(1.5m * Bets[player] + Bets[player]);
                            this.askIfUserWantToPlayAgain(player);
                            return;
                        }
                    }
                }
                //Console.Write("Dealer: ");//hide dealer hand.
                Dealer.Deal(Dealer.Hand);
                if (i == 1)
                {
                    bool blackJack = TwentyOneRules.checkForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value;
                        }
                        foreach (Player player in Players)
                        {
                            this.askIfUserWantToPlayAgain(player);
                        }
                        return;
                    }
                }



            }
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0} ", card.ToString());
                    }
                    Console.WriteLine("\n\nHit or Stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                        Console.WriteLine("You just got the {0} of {1}.",player.Hand.Last().Face, player.Hand.Last().Suit);
                    }
                    bool busted = TwentyOneRules.isBusted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted! you lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                        Bets.Remove(player);
                        Console.WriteLine("Do you want to play again?");
                        this.askIfUserWantToPlayAgain(player);
                        return; // instructor uses this line of code.
                        //break; // intructor does not have this line.
                    }
                    if (player.Hand.Count == 5)
                    {
                        Console.WriteLine("Player won!");
                        Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                        player.Balance += 2 * Bets[player];
                        Dealer.Balance -= Bets[player];
                        this.askIfUserWantToPlayAgain(player);
                        return;
                    }
                }
            }

            Dealer.isBusted = TwentyOneRules.isBusted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.shouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.isBusted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.shouldDealerStay(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying");

            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);
                    //Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);//instructor uses this line, but i think it is inefficient.
                    entry.Key.Balance += 2 * entry.Value;
                    Dealer.Balance -= entry.Value;
                }
                return;
            }
            foreach (Player player in Players)
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);
                if (playerWon == null)
                {
                    Console.WriteLine("Push! no one wins.");
                    player.Balance += Bets[player];
                    Bets.Remove(player);//instructor does not have this line.
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += 2 * Bets[player];
                    Dealer.Balance -= Bets[player];

                }
                else
                {
                    Console.WriteLine("Dealer won {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }
                Console.WriteLine("Dealer cards are: ");
                foreach (Card card in Dealer.Hand)
                {
                    Console.Write("{0}, ", card.ToString());
                }
                this.askIfUserWantToPlayAgain(player);
            }
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
