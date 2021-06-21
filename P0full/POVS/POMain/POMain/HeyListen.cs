using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using BusinessLogic;

namespace POMain
	{
	public class HeyListen
	{
		LogicClass Logic = new LogicClass();
		P0Context context = new P0Context();


		//this is the opening asking for log in info 
		//updated

		/// <summary>
		/// the opening method that starts the store
		/// </summary>
		public void Welcome()
		{
			//  Hello  //
			//Console.Write($"\tWelcome trainer to the POKEMON pokemart Pokeshop,\n\tDo you have an acount with us?\n\tType yes if you do! \n\n\n\tType exit to exit if you want to exit the program...\n\tpress anything else to create an acount!");

			Console.Write("\tWelcome to the PokeMart Express press \n\t 1 to create an acount \n\t 2 to log in: ");
			// catching the response editing it and moving on  //
			int resoponse = CheckIntResponse(Console.ReadLine(), 1, 2);

			if (resoponse == 1)
			{
				CreateAnAccount();
			}
			else if (resoponse == 2)
			{ LogIn(); }
		}




		//create an acount updated
		//follow get default store to edit comit
		//
		/// <summary>
		/// allows a user to create an account
		/// </summary>
		public void CreateAnAccount()
		{
			Console.Write($"\tWelcome to the world of pokemon young trainer!\n\t what is your firstname: ");

			string firstName = CheckStringResponse(Console.ReadLine());

			Console.Write($"\t{firstName} what is your last name: ");

			string lastName = CheckStringResponse(Console.ReadLine());

			//Console.Write($"\tWhat is your username: ");

			//string userName = CheckStringResponse(Console.ReadLine());

			//Console.Write($"\tWhat is your password: ");

			//Console.ReadLine();

			//Console.WriteLine("\tPlease choose a store by pressing\n\t1 for Pallet\n\t2 for Lavender \n\t3 for Cerulean");

			GetDefaultStore(firstName, lastName);
			//int UsersDefaultStore = CheckIntResponse(Console.ReadLine(), 1, 3);
			//ComitCustomer(FName,LName);
		}

		//this needs to have the commit updated
		/// <summary>
		/// creates a default store to shop at
		/// </summary>
		/// <param name="firstName">takes the previous methods first name</param>
		/// <param name="lastName">takes the previous methods last name</param>
		public void GetDefaultStore(string firstName, string lastName)
		{

			var storeNames = from stores in context.StoreLocations
							 where stores.LocationId > 1
							 select stores;
			int storeLocationID;
			bool stayInTheLoopBoy = true;
			do
			{
				Console.WriteLine("\t Please choose the city you'd like as your default pokemart location");

				int i = 0;
				int[] checkStoreLocation = new int[3];
				foreach (var store in storeNames)
				{
					Console.Write($"\t{store.LocationId} for the {store.LocationName} location.");
					checkStoreLocation[i] = store.LocationId;
					i++;

				}
				//gives the pw to the user

				string rawUserInput = Console.ReadLine();
				bool tryUserInput = Int32.TryParse(rawUserInput, out int userInput);

				stayInTheLoopBoy = (userInput != checkStoreLocation[0] && userInput != checkStoreLocation[1] && userInput != checkStoreLocation[2]);
				//Console.WriteLine($"{checkStoreLocation[0]}, {checkStoreLocation[1]},{checkStoreLocation[2]}, {userInput}, {stayInTheLoopBoy}");
				storeLocationID = userInput;

			} while (stayInTheLoopBoy);


			Logic.ComitCustomer(firstName, lastName, storeLocationID);

		}
		/// <summary>
		/// the method that allows a user to log in information for log in
		/// </summary>
		public void LogIn()
		{
			//takes in the last name

			Console.Write("\twhat is your first name: ");
			string firstName = CheckStringResponse(Console.ReadLine());

			//string lastName = rawLastName.ToLower().Trim();

			Console.Write("\twhat is your last name: ");

			string lastName = CheckStringResponse(Console.ReadLine());

			//string firstName = rawFirstName.ToLower().Trim();
			//I got help with this from a lot of people

			Customer customer;
			bool responceToLogin = Logic.LogInCheck(firstName, lastName, out customer);

			if (responceToLogin == true)
			{

				Store store = new Store();
				//Customer customer = new Customer();
				store.theStore(customer);

			}
			else
			{
				Console.WriteLine("\tThe information you put was incorrect we will go back to the home page: ");
				Welcome();
			}
			//bool safe = true;
			//int pwAttempts = 3;
			//int pass = 0;
			//while (safe) 
			//{
			//Console.Write($"\n\twhat is your password? ");

			//	//while (true)
			//	//{
			//var key = System.Console.ReadKey(true);
			//	//	if (key.Key == ConsoleKey.Enter)
			//	//		break;
			//	//	pass += key.KeyChar;
			//	//}

			//	if (passwords == pass)
			//	{
			//		Console.WriteLine("Succesful LogIn!");

			//		// enter store;
			//	}

			//	pwAttempts--;
			//	Console.WriteLine($"\nyou have {pwAttempts} attempts left");

			//	if (pwAttempts <= 0) 
			//	{
			//		CreateAnAccount();
			//	}



			//}




		}

		/// <summary>
		/// checks if the user still wants to use the app
		/// </summary>
		/// <returns></returns>
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



		/// <summary>
		/// outo comision at the moment
		/// </summary>
		public void exit()
		{
			Console.WriteLine("\tHey, \n\thave a good day!");
			Console.WriteLine();
			//if (exit.ToLower() == "exit")


		}

		//needs to check for string values
		//needs to check for string values
		//needs to check for string values

		/// <summary>
		/// validates the users int inputs
		/// </summary>
		/// <param name="userInput">what ever the users input is</param>
		/// <param name="intMin">min int</param>
		/// <param name="intMax">max int</param>
		/// <returns></returns>
		public int CheckIntResponse(string userInput, int intMin, int intMax)
		{
			int intToCheck = 0;

			bool boolintToCheck = Int32.TryParse(userInput, out intToCheck);


			if (intToCheck < intMin && intToCheck > intMax)
			{
				do {
					Console.WriteLine("invalid input");
					boolintToCheck = Int32.TryParse(userInput, out intToCheck);

				} while (intToCheck > intMax && intToCheck <= intMax && boolintToCheck == false);
			}
			return intToCheck;

		}
		/// <summary>
		/// validates users string inputs
		/// </summary>
		/// <param name="userInput">just needs the users strings</param>
		/// <returns></returns>
		public string CheckStringResponse(string userInput)
		{
			userInput.Trim().ToLower();
			if (userInput.Length > 20 || (string.IsNullOrEmpty(userInput)))
			{
				do
				{
					Console.WriteLine("\n\tYour input is too long or you just pressed enter try again");
					userInput.Trim().ToLower();
					userInput = Console.ReadLine();

				} while (userInput.Length > 20 || string.IsNullOrEmpty(userInput));

			}

			return userInput;

		}


	}
}