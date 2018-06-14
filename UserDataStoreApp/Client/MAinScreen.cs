using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;

namespace UserDataStoreApp.Client
{
    public class MainScreen
    {

        public static void RunMainScreen()
        {
            var userServices = new UserServices();
            int userSelection = 0;

            while (userSelection != 3)
            {
                Console.Clear();

                Console.WriteLine("\n\nPlease select an opption:\n1.Admin\n2.Shop\n3.Exit\n ");
                try
                {
                    userSelection = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry, could not understand selection as : " + e.Message);
                }

                Console.Clear();

                switch(userSelection){
                    case 1:
                        Console.WriteLine("Are you an admin? (y or n)");
                        string isAdmin = Console.ReadLine();
                        if(!string.Equals(isAdmin.ToLower(), "y")){
                            Console.WriteLine("Sorry, this option is for admins only. Please press any key to continue.");
                            Console.ReadLine();
                            break;
                        }else{
                            Console.Clear();
                            AdminScreen.RunAdminScreen();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please enter your name: ");
                        string userName = Console.ReadLine();
                        if(userServices.GetUser(userName) == null){
                            Console.WriteLine("Sorry, you need to be added to the shop by an admin.");
                            break;
                        }else{
                             // Shopscreen.RunShopScreen();
                        }
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection.");
                        break;
                }
            }

        }
    }
}
