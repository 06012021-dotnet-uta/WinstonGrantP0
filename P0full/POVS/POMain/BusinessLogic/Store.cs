﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace BusinessLogic
{
	public class Store
	{
		P0Context context = new P0Context();
		LogicClass logic = new LogicClass();


		public void theStore(Customer user)
		{

			var locationList = context.StoreLocations.ToList();


			//var storeloc1 = from c in context.StoreLocations
			//				where c.LocationId == 3
			//				select c;
			//var storeloc2 = from c in context.StoreLocations
			//				where c.LocationId == 4
			//				select c;
			//var storeloc3 = from c in context.StoreLocations
			//				where c.LocationId == 5
			//				select c;


			Console.WriteLine($"\twelcome {user.Fname}");

			var defaultLocation = (from x in locationList where x.LocationId == user.DefaultStore select x).FirstOrDefault();

			Console.WriteLine($"\t We see you like to frequent {defaultLocation.LocationName}");


			Console.Write($"\twould you like to change locations? type yes if so: ");
			string userResponseToLocationChange = logic.CheckStringResponse(Console.ReadLine());

			if ((userResponseToLocationChange).StartsWith("y"))
			{
				int i = 0;
				List<int> sizeOfLocations = new List<int> ();
				Console.WriteLine("\n\twould you like to choose: ");
				foreach (var a in locationList)
				{
					sizeOfLocations[i] = a.LocationId;
					Console.WriteLine($"\n\t {a.LocationId} for {a.LocationName}");
					i++;
				}
				sizeOfLocations.Sort();

				int userToLocationChange = logic.CheckIntResponse(Console.ReadLine(), (sizeOfLocations[0]), (sizeOfLocations[i - 1]));

				StoreLocation storeToGoTo = (from x in locationList where x.LocationId == userToLocationChange select x).FirstOrDefault();

				SpecificStore(user, storeToGoTo);
			}//if

			SpecificStore(user, defaultLocation);
		}//the store

		 //got this from techiedelite

		protected void SpecificStore(Customer currentCustomer, StoreLocation store)
			{


			}

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

			var storeProductID = from i in context.Inventories
									join j in context.Products on i.ProductId equals j.ProductId
									orderby i.InventoryId
									select i.InventoryId;
			int[] productID = new int[storeProductName.Count()];
			foreach (var a in storeProductID)
			{
				productID[w] = a;
				w++;
			}
			w = 0;


			//the first number is the inventory name the second is the amount
			Dictionary<string, int> shoppingCart = new Dictionary<string, int>();

			bool istrue1 = true;
			Console.WriteLine($"\n\tThanks for Picking the {palletTown.LocationName} pokemart! \n\there are our wares!");
			do{ 
				for (var i = 0; i <= storeProductInv.Count()-1; i++)
					{
					Console.WriteLine($"\t we have {productInv[i]} {productName[i]}s which is a {productDesc[i]} press {productID[i]} to begin purchase of item");
					Console.WriteLine();
					}
					;
			
					string userInput = Console.ReadLine();
					bool booluserInup = Int32.TryParse(userInput, out int checkedUsetInput);
				if (productID.Contains(checkedUsetInput))
				{
					bool isTrue = true;
					do
					{
						Console.WriteLine($"\n\thow many would you like to add? ");
						string userInputQuant = Console.ReadLine();
						bool booluserInupQuant = Int32.TryParse(userInput, out int checkedUsetInputQuant);
						if (checkedUsetInputQuant >= productInv[checkedUsetInput] || checkedUsetInputQuant < 0)
						{
							isTrue = true;
							Console.WriteLine("\tYour input was either too big or too small try again or\n\ttype 0 to look for more items or leave");

						}
						else if (checkedUsetInputQuant > 0)
						{
							isTrue = false;
							Console.WriteLine($"\tYou have added {checkedUsetInputQuant} of {productName[checkedUsetInput]} to your cart! ");
							shoppingCart.Add(productName[checkedUsetInput], checkedUsetInputQuant);
							Console.WriteLine($"\tSo far you have: ");

							//PrintShoppingKart(shoppingCart);

							foreach(KeyValuePair<string,int > entry in shoppingCart)
							{
								Console.WriteLine("\tyou have " + entry.Key + ", of quantity " + entry.Value + " in your shopping cart");
								Console.WriteLine("\tTo checkout type checkout else keep shopping!");
							}

						}
						else { isTrue = false; }


					} while (isTrue);

				}
				else if (userInput.ToLower().Equals("checkout"))
				{
					//CheckOut(user, shoppingCart, palletTown.LocationId);
					Console.WriteLine("checkout is down");
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

			//var ceruleanInventory = storeinven.SingleOrDefault();
			var cerulean = storeloc2.SingleOrDefault();

			var storeProductName = from i in context.Inventories
								   join j in context.Products on i.ProductId equals j.ProductId
								   orderby i.InventoryId
								   select j.ProductName;
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

			var storeProductID = from i in context.Inventories
								 join j in context.Products on i.ProductId equals j.ProductId
								 orderby i.InventoryId
								 select i.InventoryId;
			int[] productID = new int[storeProductName.Count()];
			foreach (var a in storeProductID)
			{
				productID[w] = a;
				w++;
			}
			w = 0;


			//the first number is the inventory name the second is the amount
			Dictionary<string, int> shoppingCart = new Dictionary<string, int>();

			bool istrue1 = true;
			Console.WriteLine($"\tThanks for Picking the {cerulean.LocationName} pokemart! \n\there are our wares!");
			do
			{
				for (var i = 0; i <= storeProductInv.Count() - 1; i++)
				{
					Console.WriteLine($"\t we have {productInv[i]} {productName[i]}s which is a {productDesc[i]} press {productID[i]} to begin purchase of item");
					Console.WriteLine();
				}
					;

				string userInput = Console.ReadLine();
				bool booluserInup = Int32.TryParse(userInput, out int checkedUsetInput);
				if (productID.Contains(checkedUsetInput))
				{
					bool isTrue = true;
					do
					{
						Console.WriteLine($"\thow many would you like to add? ");
						string userInputQuant = Console.ReadLine();
						bool booluserInupQuant = Int32.TryParse(userInput, out int checkedUsetInputQuant);
						if (checkedUsetInputQuant >= productInv[checkedUsetInput] || checkedUsetInputQuant < 0)
						{
							isTrue = true;
							Console.WriteLine("\tYour input was either too big or too small try again or\n\ttype 0 to look for more items or leave");

						}
						else if (checkedUsetInputQuant > 0)
						{
							isTrue = false;
							Console.WriteLine($"\tYou have added {checkedUsetInputQuant} of {productName[checkedUsetInput]} to your cart! ");
							shoppingCart.Add(productName[checkedUsetInput], checkedUsetInputQuant);
							Console.WriteLine($"\tSo far you have: ");

							//PrintShoppingKart(shoppingCart);

							foreach (KeyValuePair<string, int> entry in shoppingCart)
							{
								Console.WriteLine("\tyou have " + entry.Key + ", of quantity " + entry.Value + " in your shopping cart");
								Console.WriteLine("\tTo checkout type checkout else keep shopping!");
							}

						}
						else { isTrue = false; }


					} while (isTrue);

				}
				else if (userInput.ToLower().Equals("checkout"))
				{
					//CheckOut(user, shoppingCart, cerulean.LocationId);
					Console.WriteLine("check out is down at the moment");
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

		public void Lavender(Customer user) 
		{
			
			var storeloc3 = from c in context.StoreLocations
							where c.LocationId == 5
							select c;
			var storeinven = from i in context.Inventories
							 join c in context.StoreLocations on i.LocationId equals 5
							 select i;

			//var lavanderInventory = storeinven.SingleOrDefault();
			var lavander = storeloc3.SingleOrDefault();

			var storeProductName = from i in context.Inventories
								   join j in context.Products on i.ProductId equals j.ProductId
								   orderby i.InventoryId
								   select j.ProductName;
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

			var storeProductID = from i in context.Inventories
								 join j in context.Products on i.ProductId equals j.ProductId
								 orderby i.InventoryId
								 select i.InventoryId;
			int[] productID = new int[storeProductName.Count()];
			foreach (var a in storeProductID)
			{
				productID[w] = a;
				w++;
			}
			w = 0;


			//the first number is the inventory name the second is the amount
			Dictionary<string, int> shoppingCart = new Dictionary<string, int>();

			bool istrue1 = true;
			Console.WriteLine($"\tThanks for Picking the {lavander.LocationName} pokemart! \n\there are our wares!");
			do
			{
				for (var i = 0; i <= storeProductInv.Count() - 1; i++)
				{
					Console.WriteLine($"\t we have {productInv[i]} {productName[i]}s which is a {productDesc[i]} press {productID[i]} to begin purchase of item");
					Console.WriteLine();
				}
					;

				string userInput = Console.ReadLine();
				bool booluserInup = Int32.TryParse(userInput, out int checkedUsetInput);
				if (productID.Contains(checkedUsetInput))
				{
					bool isTrue = true;
					do
					{
						Console.WriteLine($"\thow many would you like to add? ");
						string userInputQuant = Console.ReadLine();
						bool booluserInupQuant = Int32.TryParse(userInput, out int checkedUsetInputQuant);
						if (checkedUsetInputQuant >= productInv[checkedUsetInput] || checkedUsetInputQuant < 0)
						{
							isTrue = true;
							Console.WriteLine("\tYour input was either too big or too small try again or\n\ttype 0 to look for more items or leave");

						}
						else if (checkedUsetInputQuant > 0)
						{
							isTrue = false;
							Console.WriteLine($"\tYou have added {checkedUsetInputQuant} of {productName[checkedUsetInput]}to your cart! ");
							shoppingCart.Add(productName[checkedUsetInput], checkedUsetInputQuant);
							Console.WriteLine($"\tSo far you have: ");

							//PrintShoppingKart(shoppingCart);

							foreach (KeyValuePair<string, int> entry in shoppingCart)
							{
								Console.WriteLine("\tyou have " + entry.Key + ", of quantity " + entry.Value + " in your shopping cart");
								Console.WriteLine("\tTo checkout type checkout else keep shopping!");
							}

						}
						else { isTrue = false; }


					} while (isTrue);

				}
				else if (userInput.ToLower().Equals("checkout"))
				{
					//CheckOut(user, shoppingCart, lavander.LocationId);
					Console.WriteLine("checkout is down at the moment");
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

		public void CheckOut(Customer user, Dictionary<string, int> dic, int storeId)
		{
			int w = 0;
			int[] itemID = new int[dic.Count() - 1];
			string[] itemNames = new string[dic.Count()-1];
			foreach (KeyValuePair<string, int> entry in dic)
			{
				Console.WriteLine("\tyou have " + entry.Key + ", of quantity " + entry.Value + " in your shopping cart");
				itemNames[w] += entry.Key;
				itemID[w] += entry.Value;

				
			}

			var storeloc1 = from c in context.StoreLocations
							where c.LocationId == storeId
							select c;
			var palletTown = storeloc1.SingleOrDefault();

			
			
			var storeProductName = from i in context.Inventories
								   join j in context.Products on i.ProductId equals j.ProductId
								   orderby i.InventoryId
								   select j.ProductName;
			 w = 0;
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

			var storeProductID = from i in context.Inventories
								 join j in context.Products on i.ProductId equals j.ProductId
								 orderby i.InventoryId
								 select i.InventoryId;
			int[] productID = new int[storeProductName.Count()];
			foreach (var a in storeProductID)
			{
				productID[w] = a;
				w++;
			}
			w = 0;


		}

	}






}
