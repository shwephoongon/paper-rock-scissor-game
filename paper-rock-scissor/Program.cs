using System;


namespace ConsoleApp1
{
    public class Program


    {


        static string DecideOutcome(string player, string computer)
        {
            if (player == computer)
            {
                return "tie";
            }

            else if ((player == "paper" && computer == "rock") ||
                    (player == "rock" && computer == "scissor") ||
                    (player == "scissor" && computer == "paper"))
            {
                return "player wins";
            }

            else
            {
                return "player lost";
            }
        }

        static bool ValidateChoice(string choice, string[] choices)
        {
            return Array.Exists(choices, (string element) => element == choice);

        }

        static string PointSystem(int playerScore, int aiScore)
        {

            if (playerScore == 5)
            {
                return "You win";
            }

            else if (aiScore == 5)
            {
                return "You lost";
            }

            else
            {
                return "";
            }
        }

        static void GivePoint(string outcome, ref int playerScore, ref int aiScore)
        {
            if (outcome == "player wins")
            {
                playerScore++;
            }
            else if (outcome == "player lost")
            {
                aiScore++;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter player :");
            string playerName = Console.ReadLine();
            Console.WriteLine("Welcome to Paper Rock Scissor game, {0}!", playerName);
            int playerScore = 0;
            int aiScore = 0;
            while (true)
            {
                Console.Write("Pick paper, rock, or scissor:");
                string playerChoice = Console.ReadLine();
                string[] choices = { "paper", "rock", "scissor" };

                if (!ValidateChoice(playerChoice, choices))
                {
                    Console.WriteLine("Invalid choice !");
                    continue;
                }


                var random = new Random();
                int index = random.Next(0, choices.Length);
                string AIPick = choices[index];
                string outcome = DecideOutcome(playerChoice, AIPick);

                GivePoint(outcome, ref playerScore, ref aiScore);
                string result = PointSystem(playerScore, aiScore);

                Console.WriteLine("The computer picked {0}!", AIPick);
                Console.WriteLine("Your choice:{0} \n Computer choice:{1} \n Outcome:{2}", playerChoice,
                    AIPick, outcome);
                Console.WriteLine("{0}-{1}, AI-{2}", playerName, playerScore, aiScore);

                if (result == "You win")
                {
                    Console.WriteLine("Congratulations you won this match!");
                }
                else if (result == "You lost")
                {
                    Console.WriteLine("Ooops! Game Over");
                }
                if (result == "You win" || result == "You lost")
                {
                    Console.WriteLine("Do you want to play again? (yes/no)");
                    string playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "yes")
                    {
                        playerScore = 0;
                        aiScore = 0;
                    }
                    else if (playAgain != "yes") {
                        break; }
                }
            }
        }
    }
}


