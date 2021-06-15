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
	public void LogInQ()
	{
		//  Hello  //
		Console.WriteLine($"\tWelcome trainer to the POKEMON pokemart Pokeshop, \n\t Do you have an acount with us? Type yes if you do \n\t If not no worries we will create one!?");

		// catching the response editing it and moving on  //
		string resoponse = Console.ReadLine();
		string editedResponse = resoponse.Trim().ToLower();

		//if y push to log in method else push to create acount method
		if (editedResponse.StartsWith($"y"))
		{
			//go to log in
			Console.WriteLine($""); 
		}
		//go to create an acount
		Logic.CreateAnAccount();
		Console.WriteLine($""); 
	}

	//
	public bool StillShopping()
	{

		Console.WriteLine($"\tThank you for choosing us for your poke needs\n\t if you would like to keep shopping type yes");

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
		Console.WriteLine("Hey, \n have a good day!");
		//if (exit.ToLower() == "exit")


	}


}