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
        public static void RunShoppingScreen(){
            int userSelection = 0;
            Dictionary<int, Product> indexedProducts = new Dictionary<int, Product>();
            ProductServices productServices = new ProductServices();

            while(userSelection != 3){

                Console.Clear();
                Console.WriteLine("Welcome to the rare and custom items's shop!\nBelow is a list of all products currently available.");

                var allProducts = productServices.GetAllProducts();

                for(int productCount = 0; productCount < allProducts.Count; productCount++){
                    var currenProduct = allProducts[productCount];
                    indexedProducts.Add(productCount, currenProduct);
                }

                foreach(var indexedProduct in indexedProducts){
                    Console.WriteLine($"{indexedProduct.Key} - {indexedProduct.Value.ProductName}");
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

                var doesBuy = Console.ReadLine();
                if(doesBuy.ToLower() != "y" || doesBuy.ToLower() != "n"){
                    Console.WriteLine("Sorry, invalid input");
                    Console.ReadLine();
                    continue;
                }

                if(doesBuy.ToLower() == "n"){
                    continue;
                }

                
            }
        }
    }
}
