using Microsoft.Extensions.DependencyInjection;
using RockPaperScissor.RockPaperScissor.Interfaces;
using RockPaperScissor.RockPaperScissor.Service;
using System;

namespace RockPaperScissorConsole
{
    public class Program
    {
        private static char humanEntry;
        private static string consoleMessage;
        private static int computerWins;
        private static int humanWins;

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
                humanEntry = (char)Console.ReadKey().Key;
                consoleMessage = prs.StartGame(humanEntry);
                ConsoleMessage(consoleMessage);
                if (consoleMessage == "WRONG ENTRY")
                {
                    continue;
                }
                count++;

                if (consoleMessage.ToUpper() == "PLAYER WINS")
                    humanWins++;
                else if (consoleMessage.ToUpper() == "COMPUTER WINS")
                    computerWins++;
            }

            if (humanWins > computerWins) 
                ConsoleMessage("Player won the game.");
            else if (humanWins < computerWins)
                ConsoleMessage("Computer won the game.");
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
                Console.WriteLine("Please enter: P - Paper, R - Rock, S - Scissor");
                Console.WriteLine();
            }
            else if (msg == "WRONG ENTRY")
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid entry: P - Paper, R - Rock, S - Scissor");
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine(msg);
                Console.WriteLine();
            }

        }

    }

}


