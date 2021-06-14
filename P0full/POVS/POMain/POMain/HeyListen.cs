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
	public void LogInQ()
	{
		//  Hello  //
		Console.WriteLine($"\tWelcome trainer to the POKEMON pokemart Pokeshop, \n\t Do you have an acount with us? Type yes if you do \n\t If not no worries we will create one!?");

		// catching the response editing it and moving on  //
		string resoponse = Console.ReadLine();
		string editedResponse = resoponse.Trim().ToLower();

		//
		if (editedResponse.StartsWith($"y"))
		{
			Console.WriteLine($""); 
		}
		Console.WriteLine($""); 
	}

	
}