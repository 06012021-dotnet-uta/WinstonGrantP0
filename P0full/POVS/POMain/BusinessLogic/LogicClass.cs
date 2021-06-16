using System;
using System.Collections.Generic;
using DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BusinessLogic
{
	public class LogicClass
	{
		
		P0Context context = new P0Context();
		public void CreateAnAccount()
		{
			//these will be for the database creation of a new customer
			string LName;
			string FName;

			//gets first name
			do
			{
				//getting first name for log in

				Console.Write($"\tWelcome to the world of pokemon young trainer!\n\t what is your firstname: ");
				string rawFName = Console.ReadLine();
				FName = rawFName.Trim();
				//input validation for firstname

				if (FName.Length > 20 && FName == null)
					{Console.WriteLine($"\tplease give us a name under 20 characters that's also not empty please"); }
			}
			while (FName.Length > 20 || FName == null);

			//get last name

			do
			{
				Console.Write($"\t{FName} what is your last name? ");
				string rawLName = Console.ReadLine();
				LName = rawLName.Trim();
				//input validation for lastname

				if (LName.Length > 20 || LName == null)
				{ Console.WriteLine($"\tplease give us a name under 20 characters that's also not empty please"); }
			}
			while (LName.Length > 20 || LName == null);



			//put a method that comits here!
			GetDefaultStore(FName, LName);
			//ComitCustomer(FName,LName);
		}

		public void ComitCustomer(string FName, string LName,int storeID) 
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
											where stores.LocationId> 1
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
		public void LogInLastName()
		{
			//takes in the last name
			
			
				string rawLname = Console.ReadLine();

				string Lname = rawLname.ToLower().Trim();

			Console.Write("what is your first name: ");

			string rawWname = Console.ReadLine();

			string Wname = rawWname.ToLower().Trim();
			//I got help with this from a lot of people

			var check = from c in context.Customers
											where c.Lname == Lname && c.Fname == Wname
											select c;
			   var check1 = check.SingleOrDefault();


			if (check1 == null)
			{ CreateAnAccount(); }
			else
			{
				Store store = new Store();
				store.theStore(check1);
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

		public void storeAccess(string lastName) 
		{
			Console.WriteLine();


		}
	}


}
