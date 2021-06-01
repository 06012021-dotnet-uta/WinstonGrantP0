using System;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");

            Console.WriteLine("What is your name: ");
            string stringName = Console.ReadLine();
            

            Console.WriteLine($"Thank you {stringName} for complying, NOW your robot OVERLORDS want to know how old you are");
            string stringAge = Console.ReadLine();
            int intAge = int.Parse(stringAge);

            Console.WriteLine($"{stringName} is it true you are {intAge}");
        }
    }
}
