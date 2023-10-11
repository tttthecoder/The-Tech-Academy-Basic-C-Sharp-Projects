using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();
            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")
            {
                TwentyOneGame game = new TwentyOneGame();
                Player player = new Player(playerName, bank);
                player.isActivePlaying = true;
                game += player;
                while (player.isActivePlaying && player.Balance > 0)
                {
                    game.Play();
                    //Initiate a play session for logging purpose...
                    TwentyOneGamePlaySession session = new TwentyOneGamePlaySession() { PlayerName = player.Name };
                    session.DealerHand = game.Dealer.hand.ToString();
                    List<TwentyOnePlayerHand> handsForSession = player.handsAndBets.Keys.ToList();
                    //logging into session for 1st hand.
                    session.HandOne = handsForSession[0].ToString();
                    session.HandOneLostStatus = handsForSession[0].Lost;
                    session.HandOneBet = player.handsAndBets[handsForSession[0]];
                    if (handsForSession.Count >= 1)
                    {
                        //Logging for 2nd hand.
                        session.HandTwo = handsForSession[1].ToString();
                        session.HandTwoLostStatus = handsForSession[1].Lost;
                        session.HandTwoBet = player.handsAndBets[handsForSession[1]];
                        if (handsForSession.Count == 3)
                        {
                            session.HandThree = handsForSession[2].ToString();
                            session.HandThreeLostStatus = handsForSession[2].Lost;
                            session.HandThreeBet = player.handsAndBets[handsForSession[2]];
                        }
                    }

                    using (TwentyOneDbContext db = new  TwentyOneDbContext())
                    {
                        db.TwentyOneGamePlaySessions.Add(session);
                        db.SaveChanges();
                    }
                    //Logging to the database ends.

                    Console.WriteLine("Your balance is now: {0}", player.Balance);
                    game.askIfUserWantToPlayAgain(player);
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now!");
            Console.Read();

        }


    }
}
