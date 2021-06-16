using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using BusinessLogic;

public class HeyListen
{
	LogicClass Logic = new LogicClass();

	//this is the opening asking for log in info
	public void Welcome()
	{
		//  Hello  //
		Console.Write($"\tWelcome trainer to the POKEMON pokemart Pokeshop,\n\tDo you have an acount with us?\n\tType yes if you do! \n\texit if you want to exit the program...\n\tpress anything else to create an acount!");

		// catching the response editing it and moving on  //
		string resoponse = Console.ReadLine();
		string editedResponse = resoponse.Trim().ToLower();

		//if y push to log in method else push to create acount method
		if (editedResponse.StartsWith($"y"))
		{
			//go to login
			Console.Write($"\tWhat is your Lastname? ");
			Logic.LogInLastName();
		}
		else if (editedResponse == "exit")
		{
			exit();
		}
		else
		{
			//go to create an acount
			Logic.CreateAnAccount();
		}
	}
	
	public bool StillShopping()
	{

		Console.Write($"\tThank you for choosing us for your poke needs\n\tIf you would like to keep shopping type yes: ");

		string resoponse = Console.ReadLine();
		string editedResponse = resoponse.Trim().ToLower();
		if (editedResponse.StartsWith('y'))
			//keeping running the program
		{ return true; }
		//laughs in exit
		  return false; 
	}

			 


	public void exit() 
	{
		Console.WriteLine("\tHey, \n\thave a good day!");
		Console.WriteLine();
		//if (exit.ToLower() == "exit")


	}


}