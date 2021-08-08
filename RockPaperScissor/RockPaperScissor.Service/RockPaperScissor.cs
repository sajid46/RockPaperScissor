using RockPaperScissor.RockPaperScissor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.RockPaperScissor.Service
{
    public class RockPaperScissor : IRockPaperScissor
    {
        private char humanEntry;

        public RockPaperScissor()
        {
        }

        public bool IsValidEntry(char HumanEntry)
        {
            if (HumanEntry == 'P' || HumanEntry == 'R' || HumanEntry == 'S')
                return true;

            return false;
        }

        public enum GesturEnums { Paper = 1, Rock, Scissor }

        public void ConsolStartGame()
        {
            char ComputerGesture = GetComputerHand();
            ConsoleMessage();
            int count = 1;
            while (count <= 3)
            {
                ConsoleMessage(PlayGame(humanEntry, ComputerGesture));

            }
            Console.ReadKey();

        }

        public string PlayGame(char HumanEntry, char ComputerEntry)
        {
            var IsValid = IsValidEntry(HumanEntry);
            if (IsValid == false)
                return "wrong entry";

            var results = Outcome(HumanEntry, ComputerEntry);

            return results;
        }

        private string Outcome(char HumanEntry, char ComputerEntry)
        {
            var HumanGesture = GetGesture(HumanEntry);
            var ComputerGesture = GetGesture(ComputerEntry);

            if (HumanGesture == GesturEnums.Paper.ToString())
            {
                if (ComputerGesture == GesturEnums.Rock.ToString()) return "Human Wins";
                if (ComputerGesture == GesturEnums.Scissor.ToString()) return "Computer Wins";
            }
            if (HumanGesture == GesturEnums.Rock.ToString())
            {
                if (ComputerGesture == GesturEnums.Scissor.ToString()) return "Human Wins";
                if (ComputerGesture == GesturEnums.Paper.ToString()) return "Computer Wins";
            }
            if (HumanGesture == GesturEnums.Scissor.ToString())
            {
                if (ComputerGesture == GesturEnums.Paper.ToString()) return "Human Wins";
                if (ComputerGesture == GesturEnums.Rock.ToString()) return "Human Wins";
            }
            return "Its Tie";
        }

        public char GetComputerHand()
        {
            var len = Enum.GetNames(typeof(GesturEnums)).Length + 1;

            Random rnd = new Random();
            int CompuetrEntry = rnd.Next(0, len);
            return CompuetrEntry == 1 ? 'P'
                : CompuetrEntry == 2 ? 'R'
                : 'S';

        }

        public void ConsoleMessage(string msg = null)
        {
            if (msg == null)
            {
                Console.WriteLine("Welcome Rock, Paper, Scissor Game.");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Best of 3.");
                Console.WriteLine("Please enter: P - Paper, R - Rock, S - Scissor");
                Console.WriteLine("");
                humanEntry = (char)Console.ReadKey().Key;
            }
            else if (msg == "wrong entry")
            {
                Console.WriteLine("Please enter valid entry only: P - Paper, R - Rock, S - Scissor");
                Console.ReadLine();
            }

        }

        private string GetGesture(char entry)
        {
            if (entry == 'P') return GesturEnums.Paper.ToString();
            if (entry == 'R') return GesturEnums.Rock.ToString();
            if (entry == 'S') return GesturEnums.Scissor.ToString();
            return "";
        }
    }
}
