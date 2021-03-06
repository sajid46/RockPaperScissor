using RockPaperScissor.RockPaperScissor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.RockPaperScissor.Service
{
    public class RockPaperScissorService : IRockPaperScissorService
    {
        private char humanEntry;

        public RockPaperScissorService()
        {
        }

        public enum GesturEnums { Paper = 1, Rock, Scissor }
        
        public enum OutcomeEnums { Player_Wins = 1, Computer_Wins, Tie,
            Wrong_Entry
        }

        public bool IsValidEntry(char PlayerEntry)
        {
            if (PlayerEntry == 'P' || PlayerEntry == 'R' || PlayerEntry == 'S')
                return true;

            return false;
        }
        
        public string StartGame(char PlayerEntry)
        {
            char ComputerEntry = GetComputerHand();
            return PlayGame(PlayerEntry, ComputerEntry);
        }
        
        public string PlayGame(char PlayerEntry, char ComputerEntry)
        {
            var IsValid = IsValidEntry(PlayerEntry);
            if (IsValid == false)
                return OutcomeEnums.Wrong_Entry.ToString();

            var results = Outcome(PlayerEntry, ComputerEntry);

            return results;
        }
        
        private string Outcome(char PlayerEntry, char ComputerEntry)
        {
            var PlayerGesture = GetGesture(PlayerEntry);
            var ComputerGesture = GetGesture(ComputerEntry);

            if (PlayerGesture == GesturEnums.Paper.ToString())
            {
                if (ComputerGesture == GesturEnums.Rock.ToString()) return OutcomeEnums.Computer_Wins.ToString();
                if (ComputerGesture == GesturEnums.Scissor.ToString()) return OutcomeEnums.Player_Wins.ToString();
            }
            if (PlayerGesture == GesturEnums.Rock.ToString())
            {
                if (ComputerGesture == GesturEnums.Scissor.ToString()) return OutcomeEnums.Player_Wins.ToString();
                if (ComputerGesture == GesturEnums.Paper.ToString()) return OutcomeEnums.Computer_Wins.ToString();
            }
            if (PlayerGesture == GesturEnums.Scissor.ToString())
            {
                if (ComputerGesture == GesturEnums.Paper.ToString()) return OutcomeEnums.Player_Wins.ToString();
                if (ComputerGesture == GesturEnums.Rock.ToString()) return OutcomeEnums.Computer_Wins.ToString();
            }
            return OutcomeEnums.Tie.ToString(); ;
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

        private string GetGesture(char entry)
        {
            if (entry == 'P') return GesturEnums.Paper.ToString();
            if (entry == 'R') return GesturEnums.Rock.ToString();
            if (entry == 'S') return GesturEnums.Scissor.ToString();
            return "";
        }
    }
}
