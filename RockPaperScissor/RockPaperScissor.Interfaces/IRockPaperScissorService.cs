using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.RockPaperScissor.Interfaces
{
    public interface IRockPaperScissorService
    {        
        enum GesturEnums { };
        
        bool IsValidEntry(char humanKeyEntry);

        string StartGame(char PlayerEntry);
        
        string PlayGame(char PlayerEntry, char ComputerEntry);
    }
}
