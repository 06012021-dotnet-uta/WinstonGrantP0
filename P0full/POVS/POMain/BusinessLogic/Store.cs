using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace BusinessLogic
{
	class Store
	{
		P0Context context = new P0Context();

		public void theStore(Customer user)
		{
			var storeloc1 = from c in context.StoreLocations
								 where c.LocationId == 3
								 select c;
			var storeloc2 = from c in context.StoreLocations
							where c.LocationId == 4
							select c;
			var storeloc3 = from c in context.StoreLocations
							where c.LocationId == 5
							select c;

			var palletTown = storeloc1.SingleOrDefault();
			var lavender = storeloc2.SingleOrDefault();
			var cerulean = storeloc3.SingleOrDefault();


			Console.WriteLine($"\twelcome {user.Fname}");
			
			switch (user.DefaultStore)
				{
				case 3:
					Console.WriteLine($"\twe see you like to frequent {palletTown.LocationName} ");
					break;
				case 4:
					Console.WriteLine($"\twe see you like to frequent {palletTown.LocationName}");
					break;
				case 5:
					Console.WriteLine($"\twe see you like to frequent {palletTown.LocationName}");
					break;
			}

			Console.WriteLine($"\t would you like change locations? ");

			

			
		}
	}
}
