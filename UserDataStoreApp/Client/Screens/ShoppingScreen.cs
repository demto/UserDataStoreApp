using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;

namespace UserDataStoreApp.Client.Screens
{
    public class ShoppingScreen
    {
        public static void RunShoppingScreen(User user){
            int userSelection = 0;
            Dictionary<int, Product> indexedProducts = new Dictionary<int, Product>();
            ProductServices productServices = new ProductServices();
            ShoppingServices shoppingServices = new ShoppingServices();

            while(userSelection != 3){

                Console.Clear();
                Console.WriteLine("Welcome {0} to the rare and custom items's shop!\nBelow is a list of all products currently available.", user.UserName);

                indexedProducts.Clear();

                var allProducts = productServices.GetAllProducts();
                for(int productCount = 0; productCount < allProducts.Count; productCount++){
                    var currenProduct = allProducts[productCount];
                    indexedProducts.Add(productCount, currenProduct);
                }

                Console.WriteLine("Available items: \n");
                foreach(var indexedProduct in indexedProducts){
                    if (!indexedProduct.Value.IsPurchased){
                        Console.WriteLine($"{indexedProduct.Key} - {indexedProduct.Value.ProductName}");
                    }

                    continue;
                }

                Console.WriteLine("Sold items: \n");
                foreach (var indexedProduct in indexedProducts)
                {
                    if (indexedProduct.Value.IsPurchased)
                    {
                        Console.WriteLine($"{indexedProduct.Key} - {indexedProduct.Value.ProductName}");
                    }

                    continue;
                }

                Console.WriteLine("\n\nPlease select from the above list which item you would like to buy or press 3 to go back a page: ");

                Product selectedProduct;

                try{
                    userSelection = int.Parse(Console.ReadLine());
                    selectedProduct = indexedProducts[userSelection];
                }
                catch(Exception e){
                    Console.WriteLine("Sorry could not read input either as it is an invalid input or the product does not exist: " + e.Message);
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Name: {0}\nPrice: £{1}\nIs it on sale: {2}\n\n", selectedProduct.ProductName, selectedProduct.ProductPrice, selectedProduct.IsSalesProduct ? "Yes" : "No");
                Console.WriteLine("Would you like to buy? (y, n)");

                var doesBuy = Console.ReadLine()[0];
                if(doesBuy != 'y' && doesBuy != 'n'){
                    Console.WriteLine("Sorry, invalid input");
                    Console.ReadLine();
                    continue;
                }

                if(doesBuy == 'n'){
                    continue;
                }

                if(shoppingServices.PurchaseProduct(user, selectedProduct)){
                    Console.WriteLine("Purchase successful");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}
