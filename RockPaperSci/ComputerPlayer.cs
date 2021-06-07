 using System;

 namespace RockPaperSci
 {
     
 
 public class ComputerPlayer : IPlayer
    {
         string _playerName = "Overlord";
        int _gamesWon = 0;
        int _rPSChoice;

        //roll is the random class for the AI!
        Random roll = new Random();

        public string PlayerName {get => _playerName; set => _playerName = "Overlord";}
        public int GamesWon {get => _gamesWon ; set => _gamesWon = value ;}
        public int RPSChoiceInt {get => _rPSChoice ; set => _rPSChoice = value;}

        public string RoundWinLine =>("HA you thought you could beat me!");
        

        public string RoundLossLine => ("NANI! how did you know?");
        

        public string MatchLoss=>("WHO ARE YOU JOSEF JOESTAR GIVE ME A REMATCH!");
        

        public string MatchWin => ($"HAHAHA you thought you could beat {PlayerName} bwahahah");
        

        public string Intro ()
        {
            string v = $"Welcom to RO SHAM BO THUNDER DOME\nWho dare challange the great {PlayerName}?!?";
            return v;
        }

        public string INowKnowYourName (string name) => ($"You expect to win with a name like {name}");

        public string ChoosingMyWeapon()
        {
                RPSChoiceInt = roll.Next(1,4);

                return($"I, {PlayerName} have choosen {(RSB)RPSChoiceInt}");

        }
    }
 }