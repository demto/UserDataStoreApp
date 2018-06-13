using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;

namespace UserDataStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserServices userServices = new UserServices();
            int userSelection = 0;

            while(userSelection != 5){
                Console.WriteLine("Please select from the options below: " +
                                    "1. View Users in Db\n2. Update a user's name\n3. Add new User\n4. Delete User\n5. Exit");
                try
                {
                    userSelection = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not read answer as: " + e + "\nPlease try again");
                }

                switch(userSelection){
                    case 1:
                        foreach(var user in userServices.GetAllUsersFromDb()){
                            Console.WriteLine($"{user.UserId}\n{user.UserName}\n{user.NickName}\n{user.IsAdmin}\n\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please give me the name of the user: ");
                        string userName = Console.ReadLine();
                        var user2update = userServices.GetUser(userName);
                        Console.WriteLine(user2update == null ? "Sorry, user does not exist in db" : "What would you like to change the name to: ");
                        if(user2update != null){
                            var newName = Console.ReadLine();

                            if (userServices.UpdateUserName(user2update.UserId, newName))
                            {
                                Console.WriteLine("User's name is succesfully updated.");
                            };
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
                        if(userServices.SaveUser(newUser)){
                            Console.WriteLine("New User saved successfully");
                        }else{
                            Console.WriteLine("Could not save new user");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the user id for the user to be deleted: ");
                        int id = int.Parse(Console.ReadLine());
                        if(userServices.DeleteUser(id)){
                            Console.WriteLine("User successfully deleted");
                        }else{
                            Console.WriteLine("Could not delete user");
                        }
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Sorry, incorrect option");
                        break;
                }
            }
        }
    }
}
