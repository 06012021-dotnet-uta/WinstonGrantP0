using System;
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

		Dictionary<Product, int> kart = new Dictionary<Product, int>();
		



		/// <summary>
		/// takes in a user for store matching
		/// </summary>
		/// <param name="user"></param>
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


			Console.WriteLine($"\tWelcome {user.Fname}");

			var defaultLocation = (from x in locationList where x.LocationId == user.DefaultStore select x).FirstOrDefault();

			Console.WriteLine($"\tWe see you like to frequent {defaultLocation.LocationName}");


			Console.Write($"\twould you like to change locations? type yes if so: ");
			string userResponseToLocationChange = logic.CheckStringResponse(Console.ReadLine());

			if ((userResponseToLocationChange).StartsWith("y"))
			{
				int i = 0;
				//List<int> sizeOfLocations = new List<int> ();
				Console.WriteLine("\n\tWould you like to choose: ");
				foreach (var a in locationList)
				{
					//Console.WriteLine($"{a}  {i}");
					//sizeOfLocations.Add(a.LocationId);
					Console.WriteLine($"\n\t{a.LocationId} for {a.LocationName}");
					i++;
				}
				//sizeOfLocations.Sort();


				int userToLocationChange = logic.CheckIntResponse(Console.ReadLine(), (locationList[0].LocationId), (locationList[i - 1].LocationId));

				StoreLocation storeToGoTo = (from x in locationList where x.LocationId == userToLocationChange select x).FirstOrDefault();

				SpecificStore(user, storeToGoTo );
			}//if

			SpecificStore(user, defaultLocation );
		}//the store

		//got this from techiedelite


		/// <summary>
		/// welcomes to the store
		/// </summary>
		/// <param name="user">the user using the store</param>
		/// <param name="store">the store the user is using</param>
		protected void SpecificStore(Customer user, StoreLocation store)
		{
			Console.WriteLine($"\tWelcome to the {store.LocationName} pokemart!");

			

			//method goes here
			GatherCatagories(store, user);




		}
		/// <summary>
		/// gets the categories together
		/// </summary>
		/// <param name="store">need to pass a store</param>
		/// <param name="user">need to pass a customer</param>
		protected void GatherCatagories(StoreLocation store, Customer user)
		{
			//mason helped with this!!
			var productCategories = context.Inventories.Join(
				context.Products,
				inven => inven.ProductId,
				prod => prod.ProductId,
				(inven, prod) => new
				{
					ProductCategory = prod.ProductDescription,
					ProductLoctionId = inven.LocationId,
				}
				);
			var catagoriesAtThisStore = productCategories.Where(x => x.ProductLoctionId == store.LocationId).Distinct().ToList();


			Console.WriteLine("\tPlease choose the appropriate number for the catagory you want!");

			for (var i = 0; i < catagoriesAtThisStore.Count; i++)
			{
				Console.WriteLine($"\t{i} for {catagoriesAtThisStore[i].ProductCategory}");
			}
			Console.Write("\n\t");

			var userChosenCategory = logic.CheckIntResponse(Console.ReadLine(), 0, catagoriesAtThisStore.Count - 1);

			var chosonCategory = catagoriesAtThisStore[userChosenCategory].ProductCategory;

			ChoosingItemsByCategory(store, user, chosonCategory, kart);

		}


		/// <summary>
		/// shows the user the items in the catagory they asked for
		/// </summary>
		/// <param name="store"></param>
		/// <param name="user"></param>
		/// <param name="catagory"></param>
		/// <param name="kart"></param>
		protected void ChoosingItemsByCategory(StoreLocation store, Customer user, string catagory, Dictionary<Product, int> kart)
		{

			var productListQuariable = context.Inventories.Join(
				context.Products,
				invent => invent.ProductId,
				prod => prod.ProductId,
				(invent, prod) => new
				{
					ProductId = prod.ProductId,
					ProductName = prod.ProductName,
					ProductLocationId = invent.LocationId,
					ProductAmount = invent.InventoryNumber,
					ProductDesc = prod.ProductDescription,
					ProductPrice = prod.ProductPrice
				});

			var productList = productListQuariable.Where(x => x.ProductLocationId == store.LocationId && x.ProductDesc == catagory).ToList();

			var rawFinalProduct = context.Products;
			var FinalProducts = (from i in context.Inventories
								 join j in context.Products
								 on i.ProductId equals j.ProductId
								 where i.LocationId == store.LocationId
								 select j).ToList();



			Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();

				Console.WriteLine("\tPlease choose the appropriate number for the product you want:  ");

				for (int i = 0; i < productList.Count; i++)
				{
					Console.WriteLine($"\t{i} for {productList[i].ProductName} {productList[i].ProductPrice}");
				}
				
				
				Console.Write("\n\t");
				var usersItemChoice = logic.CheckIntResponse(Console.ReadLine(), 0, productList.Count - 1);
				var usersChoiseAsString = productList[usersItemChoice];

				Console.Write("\tHow many would you like to get? ");
				var userAmountChoice = logic.CheckIntResponse(Console.ReadLine(), 1, (int)productList[usersItemChoice].ProductAmount);

				var productToAdd = (from i in FinalProducts
									where i.ProductName == usersChoiseAsString.ProductName
									select i).FirstOrDefault();

				kart.Add(productToAdd, userAmountChoice);

				Console.Write("\n\tTo continue shopping press 1\n\t To checkout press 2: ");
				var answer = logic.CheckIntResponse(Console.ReadLine(),1,2);
				switch (answer)
				{
					case 1:
						Console.WriteLine("\n");
						GatherCatagories(store, user);
						break;
					case 2:
						CheckOut(store, user);
						break;
					default:
						break;
				}



			
		}

		/// <summary>
		/// shows the user the items and affect the Db
		/// </summary>
		/// <param name="store"></param>
		/// <param name="user"></param>
		public void CheckOut(StoreLocation store, Customer user) 
		{
			var finalProducts = (from a in context.Inventories
								 join j in context.Products
								 on a.ProductId equals j.ProductId
								 where a.LocationId == store.LocationId
								 select j).ToList();

			var finalInventory = (from s in context.Inventories
								  join j in context.Products
								  on s.ProductId equals j.ProductId
								  where s.LocationId == store.LocationId
								  select s).ToList();

			decimal wallet = 0;


			Console.WriteLine($"\t{user.Fname} have the following in your shopping cart");

			foreach (var item in kart) 
			{

				wallet = wallet + (item.Key.ProductPrice* item.Value);
				Console.WriteLine($"\n\t{item.Value} {item.Key.ProductName} at {item.Key.ProductPrice} per 1");
				
			}

			Console.WriteLine($"\tfor a total of {wallet}");

			//Console.WriteLine($"\n\tPress 1 to check out and 2 to go back to ordering");
			//switch (logic.CheckIntResponse(Console.ReadLine(),1,2))
			//{
			//	case 1:
			//		GatherCatagories(store, user);
			//		break;
			//	default:
			//		break;
			//}
			//DateTime date = new DateTime();


			CustomerOrder thisOrder = new CustomerOrder();
			thisOrder.CustomerOrdertime = DateTime.Now;
			thisOrder.CustomerId = user.CustomerId;
			thisOrder.LocationId = user.DefaultStore;
			try
			{
				// Add the new order object to the Database
				context.Add(thisOrder);
				context.SaveChanges();
			}
			catch
			{
				Console.WriteLine("\tThere was an issue adding the new 'Order' to the database!");
			};
			Console.WriteLine($"\tnew order: time: {thisOrder.CustomerOrdertime}, customer id: {thisOrder.CustomerId}, location id {thisOrder.LocationId}");
			var newOrderId = context.CustomerOrders.Max(x => x.CustomerOrderId);
			Console.WriteLine($"\treturned order id: {newOrderId}");

			// Update the stores inventory in the databse 
			foreach (var item in kart)
			{
				foreach (var obj in context.Inventories)
				{
					if (obj.LocationId == store.LocationId && obj.ProductId == item.Key.ProductId)
					{
						obj.InventoryNumber -= item.Value;
					}
				}
				// Add an ordered product object for each product in the shopping cart
				var newOrderedProduct = new OrderedProduct();
				newOrderedProduct.CustomerOrderId = newOrderId;
				newOrderedProduct.ProductId = item.Key.ProductId;
				newOrderedProduct.QuantityOfItems = item.Value;
				newOrderedProduct.CustomerId = user.CustomerId;
				context.Add(newOrderedProduct);
			}
			// Save Database Changes and clear user's shopping cart
			try
			{
				kart.Clear();
				context.SaveChanges();
			}
			catch
			{
				Console.WriteLine("There was an issue adding the 'Ordered Product' to the database!");
			};

			


				//var newCustomerOrder = new CustomerOrder();
				//	newCustomerOrder.CustomerOrderId = newOrderedProduct.CustomerOrderId;
				//	newCustomerOrder.CustomerId = user.CustomerId;
				//	newCustomerOrder.LocationId = store.LocationId;
				//	context.Add(newCustomerOrder);
				
				
			



			//get all items
			//get prices for all items
			//show the customer
			//commit 
		} 
		





		public void ChoosingItemsWithoutCategory(StoreLocation store, Customer user)
		{
			var productListQuariable = context.Inventories.Join(
				context.Products,
				invent => invent.ProductId,
				prod => prod.ProductId,
				(invent, prod) => new
				{
					ProductId = prod.ProductId,
					ProductName = prod.ProductName,
					ProductLocationId = invent.LocationId,
					ProductAmount = invent.InventoryNumber,
					ProductDesc = prod.ProductDescription,
					ProductPrice = prod.ProductPrice
				});

			var productList = productListQuariable.Where(x => x.ProductLocationId == store.LocationId).ToList();
		}






		//public static void PrintShoppingKart<K,V>(Dictionary<K, V> dict)
		//{
		//	foreach (KeyValuePair<K, V> entry in dict)
		//	{
		//		Console.WriteLine("\tyou have "+entry.Key + ", of quantity " + entry.Value + "in your shopping cart");
		//		Console.WriteLine("\tTo checkout type checkout else keep shopping!");
		//	}
		//}


	
		

		

		//public void CheckOut(Customer user, Dictionary<string, int> dic, int storeId)
		//{
		//	int w = 0;
		//	int[] itemID = new int[dic.Count() - 1];
		//	string[] itemNames = new string[dic.Count()-1];
		//	foreach (KeyValuePair<string, int> entry in dic)
		//	{
		//		Console.WriteLine("\tyou have " + entry.Key + ", of quantity " + entry.Value + " in your shopping cart");
		//		itemNames[w] += entry.Key;
		//		itemID[w] += entry.Value;

				
		//	}

		//	var storeloc1 = from c in Context.StoreLocations
		//					where c.LocationId == storeId
		//					select c;
		//	var palletTown = storeloc1.SingleOrDefault();

			
			
		//	var storeProductName = from i in Context.Inventories
		//						   join j in Context.Products on i.ProductId equals j.ProductId
		//						   orderby i.InventoryId
		//						   select j.ProductName;
		//	 w = 0;
		//	string[] productName = new string[storeProductName.Count()];
		//	foreach (var a in storeProductName)
		//	{
		//		productName[w] = a;
		//		w++;
		//	}
		//	w = 0;

		//	var storeProductDesc = from i in Context.Inventories
		//						   join j in Context.Products on i.ProductId equals j.ProductId
		//						   orderby i.InventoryId
		//						   select j.ProductDescription;

		//	string[] productDesc = new string[storeProductName.Count()];
		//	foreach (var a in storeProductDesc)
		//	{
		//		productDesc[w] = a;
		//		w++;
		//	}
		//	w = 0;



		//	var storeProductInv = from i in Context.Inventories
		//						  join j in Context.Products on i.ProductId equals j.ProductId
		//						  orderby i.InventoryId
		//						  select i.InventoryNumber;
		//	int[] productInv = new int[storeProductName.Count()];

		//	foreach (var a in storeProductInv)
		//	{
		//		productInv[w] = (int)a;
		//		w++;
		//	}
		//	w = 0;



		//	var storeProductPrice = from i in Context.Inventories
		//							join j in Context.Products on i.ProductId equals j.ProductId
		//							orderby i.InventoryId
		//							select j.ProductPrice;
		//	decimal[] productPrice = new decimal[storeProductName.Count()];
		//	foreach (var a in storeProductPrice)
		//	{
		//		productPrice[w] = a;
		//		w++;
		//	}
		//	w = 0;

		//	var storeProductID = from i in Context.Inventories
		//						 join j in Context.Products on i.ProductId equals j.ProductId
		//						 orderby i.InventoryId
		//						 select i.InventoryId;
		//	int[] productID = new int[storeProductName.Count()];
		//	foreach (var a in storeProductID)
		//	{
		//		productID[w] = a;
		//		w++;
		//	}
		//	w = 0;


		//}

	}








}
