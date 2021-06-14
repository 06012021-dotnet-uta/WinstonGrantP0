using System;

namespace RockPaperSci
{

    class Program
    {
        ComputerPlayer cpu = new ComputerPlayer();
        HumanPlayer human = new HumanPlayer();
        Game game = new Game();

        static void Main(string[] args)
        {

            //variable out of scope for play again to continue playing do.while loop
           string playAgain;
           
           do{ //play again do/while loop to continue

            //creating a CPU, Game and a Human player!
           
           
           

           //getting the basic info from the human!

            System.Console.WriteLine(cpu.Intro());
            
            //getting the user name
            human.WhatIsYourName();
            System.Console.WriteLine(cpu.INowKnowYourName(human.PlayerName));
            
            //asking for win conditions 
            System.Console.WriteLine(game.HowManyRoundsQ());

            //checking for win conditions
            game.HowManyRoundsMath();

                //playing the amount of matches to win from game.BestOf do loop
                do{
                    
                    //asking for RPS
                    Console.WriteLine($"Choose your weapon {human.PlayerName} \n type 1 for Rock \n type 2 for Paper \n type 3 for Sword");

                    //getting the stupid human to choose corectly
                    System.Console.WriteLine(human.ChooseYourWeapon());        

                    //keeping track of the number of games
                    game.NumberOfGames +=1;
                    
                    //       the cpu choosing Rock Paper Scissors
                    System.Console.WriteLine(cpu.ChoosingMyWeapon());


                    if ((human.RPSChoiceInt == 1 && cpu.RPSChoiceInt == 3) ||
                        (human.RPSChoiceInt == 2 && cpu.RPSChoiceInt == 1) ||
                        (human.RPSChoiceInt == 3 && cpu.RPSChoiceInt == 2)) 
                        //these are all the sceneerios in which the human wins! of course you got to hit with the NANI
                        {human.GamesWon++;

                        // space for readability
                        System.Console.WriteLine();
                        System.Console.WriteLine(cpu.RoundLossLine);
                        }

                    else if (human.RPSChoiceInt != cpu.RPSChoiceInt) 
                    //I don't have anything for a draw so all other scenerios equates to cpu win and of course a win line
                        {cpu.GamesWon++;

                        //space for readability
                        System.Console.WriteLine();
                        System.Console.WriteLine(cpu.RoundWinLine);
                        } 

                    //keeping score
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"I the almighty {cpu.PlayerName} have {cpu.GamesWon} wins\n you the puny human {human.PlayerName} have {human.GamesWon} wins"); 
                    //end of match would you like another
                }   while(human.GamesWon < game.BestOf && cpu.GamesWon < game.BestOf );

            //got to hit em with a victory or loss line
            VoiceLines.Who
            //checking if they dare take a rematch
            System.Console.WriteLine($"If you would like to be beat again type y to quit press anything");
            string Again=Console.ReadLine();
            playAgain= Again.ToLower();

            }while(playAgain=="y");

        }
    }
}
