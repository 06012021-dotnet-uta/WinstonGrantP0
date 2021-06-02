using System;

namespace RockPaperSci
{

          enum RSB
        {
            Rock = 1,
            Paper = 2,
            Sword = 3
        }

    class Program
    {

        static void Main(string[] args)
        {
            //variable out of scope
           string playAgain;
           
           do{ //play again do
                //       the call out                                 
                Console.WriteLine("Welcom to RO SHAM BO THUNDER DOME\nWho dare challange the great computer?!?");
                string antagonist = Console.ReadLine();
                //        the variables out of scope
                bool antagChoiceBool;
                int antagChoiceInt;
                Random random = new Random();
                int antagonistWins =0;
                int heroWins =0;
                int gamesPlayed = 0;

                 do{
                    do{ //input verification
                        Console.WriteLine($"Choose your weapon {antagonist} \n type 1 for Rock \n type 2 for Paper \n type 3 for Sword");
                        //        checking input        
                        string antagChoiceStg = Console.ReadLine();
                        antagChoiceBool = Int32.TryParse(antagChoiceStg, out antagChoiceInt);
                        //        checking numbers
                        if (antagChoiceInt > 3 ) System.Console.WriteLine("please select a weapon by choosing 1-3");
                        if (antagChoiceInt < 1 ) System.Console.WriteLine("please select a weapon by choosing 1-3");
                        //       the great checker           
                    } while(!antagChoiceBool || (antagChoiceInt < 1 || antagChoiceInt > 3 ));
                
                    //       the response, up the gamesplayed
                    gamesPlayed ++;
                    System.Console.WriteLine($"I see you have choosen death {antagonist}... \nI mean {(RSB)antagChoiceInt}");
                    //       the roll 
                    int heroRSBInt = random.Next(1,4); 
                    System.Console.WriteLine($"I, the all mighty computer have choosen LIIFFEE... \n I mean {(RSB)heroRSBInt}");
                
                    if ((heroRSBInt == 1 && antagChoiceInt == 3) ||
                        (heroRSBInt == 2 && antagChoiceInt == 1) ||
                        (heroRSBInt == 3 && antagChoiceInt == 2)) heroWins++;

                    else if (heroRSBInt != antagChoiceInt) antagonistWins++; 

                    System.Console.WriteLine($"I the almighty computer have {heroWins} wins\nAnd you the puny human {antagonist} have {antagonistWins} wins"); 
                    //end of match would you like another
                }   while(heroWins < 2 && antagonistWins < 2 );

                System.Console.WriteLine($"If you would like to be beat again type y");
                string Again=Console.ReadLine();
                playAgain= Again.ToLower();

            }while(playAgain=="y");

        }
    }
}
