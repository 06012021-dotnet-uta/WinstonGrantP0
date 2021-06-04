using System;

namespace RockPaperSci
{

    public class Game 
    {
       int _bestOf;
       int _numOfGames = 0;
       public int BestOf{get=> _bestOf ; set =>_bestOf = value;}
       public int NumberOfGames { get => _numOfGames; set => _numOfGames = value; }

       public void HowManyRoundsMath()
       {
            int catchNum = 0;
           do{
                bool howMany = Int32.TryParse(Console.ReadLine(), out catchNum );

                if (catchNum < 1 || catchNum >10)
                    {System.Console.WriteLine("the number has to be greater then 0 and less then 10" );}

            }
            while(catchNum < 1 || catchNum >10);

            BestOf = catchNum;

       }

       public string HowManyRoundsQ () => ($"How many rounds shall we need to win to claim victory \n let's not make this unreasonable huh?");

       public void TimeToDuel ()
       {

       }

    }
}