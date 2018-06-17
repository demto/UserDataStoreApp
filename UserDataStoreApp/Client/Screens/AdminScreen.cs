using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.Dtos;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;

namespace UserDataStoreApp.Client
{
    public static class AdminScreen
    {
        public static void RunAdminScreen(string currentUserName)
        {
            UserServices userServices = new UserServices();
            ProductServices productServices = new ProductServices();

            int userSelection = 0;

            while (userSelection != 9)
            {
                Console.Clear();

                Console.WriteLine("\n\nPlease select from the options below: " +
                                    "\n\n1. View Users in Db\n2. Update a user's name\n3. Add new User\n" +
                                    "4. Delete User\n5. View Products\n6. Update Product\n7. Add new product\n8. Delete Product\n9. Exit");
                try
                {
                    userSelection = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not read answer as: " + e.Message + "\nPlease try again");
                }

                switch (userSelection)
                {
                    case 1:
                        foreach (var user in userServices.GetAllUsersFromDb())
                        {
                            Console.WriteLine($"{user.UserId}\n{user.UserName}\n{user.NickName}\n{user.IsAdmin}\n\n");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please give me the name of the user: ");
                        string userName = Console.ReadLine();
                        var user2update = userServices.GetUser(userName);
                        Console.WriteLine(user2update == null ? "Sorry, user does not exist in db" : "What would you like to change the name to: ");
                        if (user2update != null)
                        {
                            var newProdName = Console.ReadLine();

                            if (userServices.UpdateUserName(user2update.UserId, newProdName))
                            {
                                Console.WriteLine("User's name is succesfully updated.");
                            };
                            break;
                        }
                        Console.WriteLine("Sorry, something went wrong with the update");
                        break;
                    case 3:
                        var newUser = new User();
                        Console.WriteLine("Please enter the new user's Name: ");
                        newUser.UserName = Console.ReadLine();
                        Console.WriteLine("Please enter a nick name: ");
                        newUser.NickName = Console.ReadLine();
                        Console.WriteLine("Please enter y or n to indicate if the user is an admin: ");
                        if (string.Equals(Console.ReadLine().ToLower(), "y"))
                        {
                            newUser.IsAdmin = true;
                        }
                        else
                        {
                            newUser.IsAdmin = false;
                        };
                        if (userServices.SaveUser(newUser))
                        {
                            Console.WriteLine("New User saved successfully");
                        }
                        else
                        {
                            Console.WriteLine("Could not save new user");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the user id for the user to be deleted: ");
                        int id = 0;

                        try
                        {
                            id = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Sorry, incorrect input: " + e.Message);
                            break;
                        }

                        if (userServices.DeleteUser(id))
                        {
                            Console.WriteLine("User successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Could not delete user");
                        }
                        break;
                    case 5:
                        foreach (var product in productServices.GetAllProducts())
                        {
                            Console.WriteLine($"{product.ProductId}\n{product.ProductName}\n{product.ProductPrice}\n{product.IsSalesProduct}\n\n");
                        }
                        Console.WriteLine("Please press any keys to continue");
                        Console.ReadLine();
                        break;
                    case 6 :
                        double newPrice = -1;
                        bool isSaleProduct = false;

                        Console.WriteLine("Please give me the name of the product: ");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Plese enter new name: ");
                        string newProductName = Console.ReadLine();
                        Console.WriteLine("Please enter new price: ");
                        try
                        {
                            newPrice = double.Parse(Console.ReadLine());
                        }catch(Exception e){
                            Console.WriteLine("Sorry could not read new price");
                            break;
                        }

                        if(newPrice < 0){
                            Console.WriteLine("Sorry price has to be 0 or greater");
                            break;
                        }

                        Console.WriteLine("Please enter y or n to indicate if product is on sale: ");
                        var isOnSale = Console.ReadLine();

                        if(string.Equals(isOnSale.ToLower(), "y")){
                            isSaleProduct = true;
                        }

                        var productUpdates = new ProductUpdateDto {
                            ProductName = newProductName,
                            ProductPrice = newPrice,
                            IsSalesProduct = isSaleProduct
                        };

                        if (productServices.UpdateProduct(productName, productUpdates))
                        {
                            Console.WriteLine("Product is succesfully updated.");
                            break;
                        }

                        Console.WriteLine("Sorry, something went wrong with the update");
                        break;

                    case 7:
                        isSaleProduct = false;

                        Console.WriteLine("Plese enter new name: ");
                        newProductName = Console.ReadLine();
                        Console.WriteLine("Please enter new price: ");
                        try
                        {
                            newPrice = double.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Sorry could not read new price");
                            break;
                        }

                        if (newPrice < 0)
                        {
                            Console.WriteLine("Sorry price has to be 0 or greater");
                            break;
                        }

                        Console.WriteLine("Please enter y or n to indicate if product is on sale: ");
                        isOnSale = Console.ReadLine();

                        if (string.Equals(isOnSale.ToLower(), "y")){
                            isSaleProduct = true;
                        }

                        var newProduct = new Product {
                            ProductName = newProductName,
                            ProductPrice = newPrice,
                            IsSalesProduct = isSaleProduct,
                            OwnerId = null,
                        };

                        if(productServices.AddNewProduct(newProduct)){
                            Console.WriteLine("Product successfully added.");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("Could not add product");
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Please enter the id of the product to be deleted: ");
                        var productId = 0;

                        try
                        {
                            productId = int.Parse(Console.ReadLine());
                        }catch(Exception e){
                            Console.WriteLine("Sorry could not read input as : " + e.Message  + "Please press any key");
                            break;
                        }
                        if(productServices.DeleteProduct(productId)){
                            Console.WriteLine("Product successfully deleted. Please a key to continue.");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("Error trying to delete product. Please press any keys to continue.");
                        Console.ReadLine();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Sorry, incorrect option");
                        break;
                }
            }
        }

    }
}
