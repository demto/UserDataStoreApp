using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
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

                    case 2:
                        
                }
            }
        }
    }
}
