using System;


namespace BusinessLogic
{
	public class LogicClass
	{
		public void CreateAnAccount()
		{
			//these will be for the database creation of a new customer
			string LName;
			string FName;

			//get first name
			do
			{
				Console.WriteLine($"\tWelcom to the world of pokemon young trainer! \n\t what is your firstname: ");
				string rawFName = Console.ReadLine();
				FName = rawFName.Trim();
			}
			while (FName.Length < 20 && FName != null);

			//get last name
			do
			{
				Console.WriteLine($"\t{FName} what is your last name? ");
				string rawLName = Console.ReadLine();
				LName = rawLName.Trim();
			}
			while (LName.Length < 20 && LName != null);

			Console.WriteLine($"\tHello {FName} {LName} welcome to the store"!);

			//
			//put a method that comits here!
			//
		}
	}
}
