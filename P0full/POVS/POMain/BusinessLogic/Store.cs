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
					Console.WriteLine($"\twe see you like to frequent {lavender.LocationName} ");
					break;
				case 5:
					Console.WriteLine($"\twe see you like to frequent {cerulean.LocationName} ");
					break;
			}

			Console.WriteLine($"\twould you like change locations? type yes if so");
			if (Console.ReadLine().StartsWith("y"))
			{
				bool choiceBool = true;
				while (!choiceBool)
				{
					Console.Write($"\twhich store would you like to choose: \n\t{palletTown.LocationId} for {palletTown.LocationName} or \n\t{lavender.LocationId} for {lavender.LocationId} or \n\t{cerulean.LocationId} for {cerulean.LocationId} ");

					var rawChoice = Console.ReadLine();

					choiceBool = Int32.TryParse(rawChoice, out int choice);


					switch (choice)
					{
						case 3:
							Console.WriteLine($"\twe see you like to frequent {palletTown.LocationName} ");
							Pallet(user);
							break;
						case 4:
							Console.WriteLine($"\twe see you like to frequent {lavender.LocationName}");
							Lavender(user);
							break;
						case 5:
							Console.WriteLine($"\twe see you like to frequent {cerulean.LocationName}");
							Cerulean(user);
							break;
						default:
							Console.WriteLine($"\t hahaha did you get hit with confusion? try again lol");
							break;


					}//switch
				}//while
			}//if

		}//the store
		//got this from techiedelite
		public static void PrintShoppingKart<K,V>(Dictionary<K, V> dict)
		{
			foreach (KeyValuePair<K, V> entry in dict)
			{
				Console.WriteLine("\tyou have "+entry.Key + ", of quantity " + entry.Value + "in your shopping cart");
				Console.WriteLine("\tTo checkout type checkout else keep shopping!");
			}
		}

		public void Pallet(Customer user)
		{
			var storeloc1 = from c in context.StoreLocations
							where c.LocationId == 3
							select c;
			var palletTown = storeloc1.SingleOrDefault();

			var storeProductName = from i in context.Inventories join j in context.Products on i.ProductId equals j.ProductId
								   orderby i.InventoryId select j.ProductName;
			int w = 0;
			string[] productName = new string[storeProductName.Count()];
			foreach (var a in storeProductName)
			{
				productName[w] = a;
				w++;
			}
			w = 0;

			var storeProductDesc = from i in context.Inventories
								   join j in context.Products on i.ProductId equals j.ProductId
								   orderby i.InventoryId
								   select j.ProductDescription;

			string[] productDesc = new string[storeProductName.Count()];
			foreach (var a in storeProductDesc)
			{
				productDesc[w] = a;
				w++;
			}
			w = 0;



			var storeProductInv = from i in context.Inventories
								  join j in context.Products on i.ProductId equals j.ProductId
								  orderby i.InventoryId
								  select i.InventoryNumber;
			int[] productInv = new int[storeProductName.Count()];

			foreach (var a in storeProductInv)
			{
				productInv[w] = (int)a;
				w++;
			}
			w = 0;



			var storeProductPrice = from i in context.Inventories
									join j in context.Products on i.ProductId equals j.ProductId
									orderby i.InventoryId
									select j.ProductPrice;
			decimal[] productPrice = new decimal[storeProductName.Count()];
			foreach (var a in storeProductPrice)
			{
				productPrice[w] = a;
				w++;
			}
			w = 0;


			//the first number is the inventory name the second is the amount
			Dictionary<string, int> shoppingCart = new Dictionary<string, int>();

			bool istrue1 = false;
			Console.WriteLine($"\tThanks for Picking the {palletTown.LocationName} pokemart! /n/t here are our wares!");
			do{ 
				for (var i = 0; i <= storeProductInv.Count(); i++)
					{
					Console.WriteLine($"\t we have {productInv[i]} {productName[i]}s which is a {productDesc[i]} press {productInv[i]} to begin purchase of item");
					}
					;
			
					string userInput = Console.ReadLine();
					bool booluserInup = Int32.TryParse(userInput, out int checkedUsetInput);
				if (productInv.Contains(checkedUsetInput))
				{
					bool isTrue = true;
					do
					{
						Console.WriteLine($"\thow many would you like to add? ");
						string userInputQuant = Console.ReadLine();
						bool booluserInupQuant = Int32.TryParse(userInput, out int checkedUsetInputQuant);
						if (checkedUsetInputQuant >= productInv[checkedUsetInput] && checkedUsetInputQuant > 0)
						{
							isTrue = true;
							Console.WriteLine("\tYour input was either too big or too small try again or\n\ttype 0 to look for more items or leave");

						}
						else if (checkedUsetInputQuant > 0)
						{
							isTrue = false;
							Console.WriteLine($"\tYou have added {checkedUsetInputQuant} to your cart! ");
							shoppingCart.Add(productName[checkedUsetInput], checkedUsetInputQuant);
							Console.WriteLine($"\tSo far you have: ");

							PrintShoppingKart(shoppingCart);

						}
						else { isTrue = false; }


					} while (isTrue);

				}
				else if (userInput.ToLower().Equals("checkout"))
				{
					CheckOut(user, shoppingCart, palletTown.LocationId);
				}
				else if (checkedUsetInput == 0)
				{
					Console.WriteLine("\t Hey, \n\t have a good day! ");
					istrue1 = false;
				}
				
				else 
				{
					Console.WriteLine("\tYour input wasn't undertood wana try again... or type 0 to logout");
				}



			} while (istrue1);





		}
		public void Cerulean(Customer user) 
		{
			
			var storeloc2 = from c in context.StoreLocations
							where c.LocationId == 4
							select c;

			var storeinven = from i in context.Inventories
							 join c in context.StoreLocations on i.LocationId equals 4
							 select i;

			var lavenderInventory = storeinven.SingleOrDefault();
			var lavender = storeloc2.SingleOrDefault();
			

		}

		public void Lavender(Customer user) 
		{
			
			var storeloc3 = from c in context.StoreLocations
							where c.LocationId == 5
							select c;
			var storeinven = from i in context.Inventories
							 join c in context.StoreLocations on i.LocationId equals 5
							 select i;

			var ceruleanInventory = storeinven.SingleOrDefault();
			var cerulean = storeloc3.SingleOrDefault();

		
		
		}

		public void CheckOut(Customer user, Dictionary<string, int> dic, int storeId)
		{
			Console.WriteLine("");
		}

	}






}
