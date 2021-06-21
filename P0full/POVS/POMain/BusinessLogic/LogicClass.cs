using System;
using System.Collections.Generic;
using DataBase;
using System.Linq;



namespace BusinessLogic
{
	public class LogicClass
	{

		P0Context context = new P0Context();

		/// <summary>
		/// commits the users to the database
		/// </summary>
		/// <param name="FName">needs the users first name</param>
		/// <param name="LName">needs the users last name</param>
		/// <param name="storeID">needs a default store</param>
		public void ComitCustomer(string FName, string LName, int storeID)
		{
			//saves the username and gens the id as a password
			

			var newcust = new DataBase.Customer();

			newcust.Fname = FName;
			newcust.Lname = LName;
			newcust.DefaultStore = storeID;
			context.Add(newcust);
			context.SaveChanges();

			Console.WriteLine($"\tHello {FName} {LName} Congratulations on creating an acount!");

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="returnCustomer"></param>
		/// <returns></returns>
		public bool LogInCheck(string firstName, string lastName, out Customer returnCustomer)
		{
			//Console.WriteLine( context.Customers.Count());
			try
			{
				var checkInformationRaw = from c in context.Customers
							where c.Lname == lastName && c.Fname == firstName
							select c;
				 returnCustomer = checkInformationRaw.FirstOrDefault();

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

		/// <summary>
		/// This checks responseses from user that are supposed to be int
		/// </summary>
		/// <param name="userInput">an integer from the user</param>
		/// <param name="intMin">what the min can be</param>
		/// <param name="intMax">what the max can be</param>
		/// <returns>the checked integer</returns>
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

		/// <summary>
		/// checks string inputs
		/// </summary>
		/// <param name="userInput">what ever the input was</param>
		/// <returns>validated strings</returns>
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
