using System;
namespace RockPaperSci;
{
    public class VoiceLines
    {
        public void WhoWon{
            System.Console.WriteLine(((Program.human.GamesWon>Program.cpu.GamesWon)?Program.cpu.MatchLoss:Program.cpu.MatchWin));
        }
        
    }
    
}
    
