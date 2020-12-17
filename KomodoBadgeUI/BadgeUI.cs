using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_BadgeRepository;

namespace KomodoBadgeUI
{
    public class BadgeUI
    {
        private Repo repoWindow = new Repo();


        public void Run()
        {
            repoWindow.loadData();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                  "1. Create a new badge\n" +
                  "2. Update doors on an existing badge\n" +
                  "3. Delete all doors from an existing badge\n" +
                  "4. Show a list with all badge numbers and door access\n" +
                  "20. Exit The Program");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewBadge()
                        break;

                    case "2":
                        UpdateDoors();
                        break;

                    case "3":
                        DeleteAllDoors();
                        break;

                    case "4":
                        ShowEverything();

                    case "20":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewBadge()
        {
            Badge newBadge = new Badge();
            Console.WriteLine("What is the new badge number? ");

            string userInput = Console.ReadLine();
            int tempInt = int.Parse(userInput);

            newBadge.BadgeID = tempInt;


            List<string> doorNames = new List<string>();
            while (userInput.ToLower() != "n")
            {
                Console.WriteLine("List a door this badge needs access to: ");
                userInput = Console.ReadLine();
                doorNames.Add(userInput);
                Console.WriteLine("Any other doors (y/n)? ");
                userInput = Console.ReadLine();
            }

            newBadge.DoorNames = doorNames;

            repoWindow.CreateNewBadge(newBadge.BadgeID, newBadge);         

        }

        private void UpdateDoors()
        {
            //propmt for badge number
            Badge updateBadge = new Badge();
            Console.WriteLine("What is the badge number? ");

            string userInput = Console.ReadLine();
            int tempInt = int.Parse(userInput);

            //retrieve the badge object using a repo function
            updateBadge = repoWindow.ReturnOneBadge(tempInt);
            //copy the doornames to a temporary list
            List<string> doorList = new List<string>();
            doorList = updateBadge.DoorNames;

            //list out the doors to the user
            //12345 has access to doors A5 & A7
            string doorString = userInput + " has access to doors  ";
            foreach (string item in doorList)
            {
                doorString += item + " & ";
            }
            //userInput 12345 has access to doors A5 & A7 & 
            if (doorString.EndsWith(" & "))
            {
                doorString = doorString.Substring(0, doorString.Length - 3);
            }
            Console.WriteLine(doorString);
            //prompt user to add/remove a door
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door ");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Which door do you want to remove? ");
                    string doorInput = Console.ReadLine();
                    doorList.Remove(doorInput);
                    updateBadge.DoorNames = doorList;
                    repoWindow.UpdateDoors(tempInt, updateBadge);
                    break;

                default:
                    break;
            }

            //update the door list

            //use repo function to update the badge with the new door list


        }


    }
}


    

