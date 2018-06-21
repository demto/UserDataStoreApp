﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;
using UserDataStoreApp.Client.Screens;
using UserDataStoreApp.Client.ViewModels;
using UserDataStoreApp.Logger;
using UserDataStoreApp.Shared.Enums;
using UserDataStoreApp.Shared.Services;

namespace UserDataStoreApp.Client
{
    public class MainScreen
    {

        public static void RunMainScreen()
        {
            var viewModel = new MainScreenViewModel();
            ILogger Trace = new GenericLoggerAdapter();

            var userServices = new UserServices();
            int userSelection = 0;

            while (userSelection != 4)
            {
                Console.Clear();
                Console.WriteLine(string.Format("{0}",
                    viewModel.CurrentUserName == null ?
                        "Please Change user to enjoy the most of the app!" : 
                        $"Welcome{viewModel.CurrentUserName}!\n\n"));
                Console.WriteLine("\n\nPlease select an option:\n1.Change User\n2.Admin\n3.Shop\n4.Exit\n ");
                try
                {
                    userSelection = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry, could not understand selection as : " + e.Message);
                    Trace.TraceError("Incorrect User Selection", e.Message, SeverityLevel.Error);
                }

                Console.Clear();

                switch(userSelection){
                    case 1:
                        Console.WriteLine("Please enter your name: ");
                        string currentUserName = Console.ReadLine();
                        try
                        {
                            viewModel.AssignUserName(currentUserName);
                        }catch(ArgumentNullException e){
                            Console.WriteLine(e.Message);
                            Trace.TraceError("Could not find user", e.Message, SeverityLevel.Warning);
                            Console.ReadLine();
                        }
                        continue;
                    case 2:
                            Console.Clear();
                            if(!viewModel.IsAdmin){
                            Console.WriteLine("Sorry this section is for admmins only!");
                            Console.ReadLine();
                            continue;
                        }
                            AdminScreen.RunAdminScreen(viewModel.CurrentUserName);
                        continue;
                    case 3:
                            if(viewModel.CurrentUserName == null){
                            Console.WriteLine("Please Change to an existing User First!");
                            Console.ReadLine();
                            continue;
                        }
                             ShoppingScreen.RunShoppingScreen(viewModel.CurrentUser);
                        continue;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection.");
                        Console.ReadLine();
                        continue;
                }
            }

        }
    }
}
