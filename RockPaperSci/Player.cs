using System;

namespace RockPaperSci
{
     interface IPlayer
    {
         string PlayerName {get ; set ;}

         int GamesWon { get ; set ; }

         int RPSChoiceInt {get ; set ; }    

    }

    public class HumanPlayer : IPlayer
    {
        string _playerName;
        int _gamesWon = 0;
        int _rPSChoiceInt;


        public string PlayerName {get => _playerName; set => _playerName = value;} 
        public int GamesWon {get => _gamesWon ; set => _gamesWon = value ;}
        public int RPSChoiceInt {get => _rPSChoiceInt ; set => _rPSChoiceInt = value; }

        public void WhatIsYourName()
        {
            //gets name and mocks name
            PlayerName = Console.ReadLine();
        }


        public string ChooseYourWeapon ()
        {  
                int RPSChoiceInt;
                string RPSChoiceStg;
                bool RPSChoiceBool;
                //keep em cycling through if they keep failing to choose 1-3
            do{    
                //getting and parsing users choice of Rock Paper sword
                RPSChoiceStg = Console.ReadLine();
                RPSChoiceBool = Int32.TryParse(RPSChoiceStg, out RPSChoiceInt);
                
                //checking numbers are good and if they are even numbers
                if (RPSChoiceInt > 3 || RPSChoiceInt < 1 ) System.Console.WriteLine("please select a weapon by choosing 1-3 \n 1=rock 2=paper 3=sword");
            }
            while(!RPSChoiceBool || (RPSChoiceInt < 1 && RPSChoiceInt > 3 ));

            // setting the RPS Choice for the showdown
            this.RPSChoiceInt = RPSChoiceInt;

            //letting the player now what they have done
            return ($"I see you have choosen death... \nI mean {(RSB)RPSChoiceInt}");

        }

        //public void Roll()
    }

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
