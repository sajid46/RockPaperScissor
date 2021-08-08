using Microsoft.Extensions.DependencyInjection;
using RockPaperScissor.RockPaperScissor.Interfaces;
using RockPaperScissor.RockPaperScissor.Service;
using System;

namespace RockPaperScissorConsole
{
    public class Program
    {
        private static char playerHandGesture;
        private static string consoleMessage;
        private static int computerWins;
        private static int humanWins;
        enum OutcomeEnums
        {
            Player_Wins = 1, Computer_Wins, Tie,
            Wrong_Entry
        }

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IRockPaperScissorService, RockPaperScissorService>()
            .BuildServiceProvider();
            
            PlayGame(serviceProvider);

        }

        private static void PlayGame(ServiceProvider serviceProvider)
        {
            ConsoleMessage();
            var prs = serviceProvider.GetService<IRockPaperScissorService>();
            int count = 0;
            while (count < 3)
            {
                playerHandGesture = (char)Console.ReadKey().Key;
                consoleMessage = prs.StartGame(playerHandGesture);

                ConsoleMessage(consoleMessage);
                if (consoleMessage == OutcomeEnums.Wrong_Entry.ToString())
                {
                    continue;
                }
                count++;

                if (consoleMessage == OutcomeEnums.Player_Wins.ToString())
                    humanWins++;
                else if (consoleMessage == OutcomeEnums.Computer_Wins.ToString())
                    computerWins++;
            }

            if (humanWins > computerWins) 
                ConsoleMessage("Player wins the game.");
            else if (humanWins < computerWins)
                ConsoleMessage("Computer wins the game.");
            else 
                ConsoleMessage("It's a tie.");
        }

        public static void ConsoleMessage(string msg = null)
        {
            if (msg == null)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome Rock, Paper, Scissor Game.");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("Best of 3 Game.");
                Console.WriteLine("");
                Console.WriteLine("Please enter: P - Paper, R - Rock, S - Scissor ");
                Console.WriteLine();
            }
            else if (msg == OutcomeEnums.Wrong_Entry.ToString())
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid entry: P - Paper, R - Rock, S - Scissor");
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine(msg.Replace("_", " "));
                Console.WriteLine();
            }

        }

    }

}


