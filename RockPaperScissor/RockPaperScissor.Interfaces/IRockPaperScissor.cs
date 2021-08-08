using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.RockPaperScissor.Interfaces
{
    public interface IRockPaperScissor
    {
        void ConsolStartGame();
        enum GesturEnums { };
        bool IsValidEntry(char humanKeyEntry);

        string PlayGame(char HumanEntry, char ComputerEntry);

        void ConsoleMessage(string msg = null);
    }
}
