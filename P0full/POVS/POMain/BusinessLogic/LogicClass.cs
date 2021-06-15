using System;
using DataBase;
using Microsoft.EntityFrameworkCore;


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
				Console.WriteLine($"\tWelcom to the world of pokemon young trainer! \n\t what is your firstname: ");
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
				Console.WriteLine($"\t{FName} what is your last name? ");
				string rawLName = Console.ReadLine();
				LName = rawLName.Trim();
				//input validation for lastname
				if (LName.Length > 20 || LName == null)
				{ Console.WriteLine($"\tplease give us a name under 20 characters that's also not empty please"); }
			}
			while (LName.Length > 20 || LName == null);

			Console.WriteLine($"\tHello {FName} {LName} Congradulations on creating an acount!");

			//
			//put a method that comits here!
			ComitCustomer(FName,LName);
			//
		}

		public void ComitCustomer(string FName, string LName) 
		{
			var newcust = new DataBase.Customer();

			newcust.Fname = FName;
			newcust.Lname = LName;

			context.Add(newcust);
			context.SaveChanges();


		}
	}
}
