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
                Game game = new TwentyOneGame();
                Player player = new Player(playerName, bank);
                
                player.isActivePlaying = true;
                game += player;
                while (player.isActivePlaying && player.Balance > 0)
                {
                    player.handsAndBets = new Dictionary<TwentyOnePlayerHand, int>();
                    Console.WriteLine("And how many hands would you like to play?");
                    int numOfHands = Convert.ToInt32(Console.ReadLine());
                    player.numOfHands = numOfHands;
                    game.Play();
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
