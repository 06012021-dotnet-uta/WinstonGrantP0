using System;

namespace RockPaperSci
{
    

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
            while(!RPSChoiceBool || (RPSChoiceInt < 1 || RPSChoiceInt > 3 ));

            // setting the RPS Choice for the showdown
            this.RPSChoiceInt = RPSChoiceInt;

            //letting the player now what they have done
            return ($"I see you have choosen {(RSB)RPSChoiceInt}");

        }
    }