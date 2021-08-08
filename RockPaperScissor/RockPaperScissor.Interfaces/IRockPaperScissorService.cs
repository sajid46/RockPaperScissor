using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.RockPaperScissor.Interfaces
{
    public interface IRockPaperScissorService
    {        
        bool IsValidEntry(char humanKeyEntry);

        string StartGame(char PlayerEntry);
        
        string PlayGame(char PlayerEntry, char ComputerEntry);
    }
}
