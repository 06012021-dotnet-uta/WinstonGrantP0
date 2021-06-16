using System;
using DataBase;
using BusinessLogic;



namespace POMain
{
	class Program
	{
		static void Main(string[] args)
		{
			
			P0Context context = new P0Context();
			HeyListen hey = new HeyListen();
			LogicClass LC = new LogicClass();
			var stillShoping = true;
			{
				do
				{
				hey.Welcome();

				



					


					stillShoping = hey.StillShopping();
				}
				while (stillShoping);
				
			}
		}
	}
}
