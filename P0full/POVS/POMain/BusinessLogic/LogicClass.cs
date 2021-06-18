using System;
using System.Collections.Generic;
using DataBase;
using System.Linq;



namespace BusinessLogic
{
	public class LogicClass
	{

		P0Context context = new P0Context();


		public void ComitCustomer(string FName, string LName, int storeID)
		{
			//saves the username and gens the id as a password
			Console.WriteLine($"\tHello {FName} {LName} Congratulations on creating an acount!");

			var newcust = new DataBase.Customer();

			newcust.Fname = FName;
			newcust.Lname = LName;
			newcust.DefaultStore = storeID;
			context.Add(newcust);
			context.SaveChanges();

			//GetDefaultStore();

		}

		public void GetDefaultStore(string lastName, string firstName)
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
					Console.WriteLine($"\t{store.LocationId} for the {store.LocationName} location.");
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


			ComitCustomer(lastName, firstName, storeLocationID);

		}
		public bool LogInCheck(string firstName, string lastName, out Customer returnCustomer)
		{
			Console.WriteLine( context.Customers.Count());
			try
			{
				var checkInformationRaw = from c in context.Customers
							where c.Lname == lastName && c.Fname == firstName
							select c;
				 returnCustomer = checkInformationRaw.SingleOrDefault();

				if (returnCustomer == null)
				{ return false; }
				else
				{
					return true;}
			}
			catch (Exception)
			{ }

			returnCustomer = null;
			return false;

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

		public void storeAccess(string lastName) 
		{
			Console.WriteLine();


		}

		public int CheckIntResponse(string userInput, int intMin, int intMax)
		{
			int intToCheck = 0;

			bool boolintToCheck = Int32.TryParse(userInput, out intToCheck);


			if (intToCheck < intMin && intToCheck > intMax)
			{
				do
				{
					Console.WriteLine("invalid input");
					boolintToCheck = Int32.TryParse(userInput, out intToCheck);

				} while (intToCheck > intMax && intToCheck <= intMax && boolintToCheck == false);
			}
			return intToCheck;

		}

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
