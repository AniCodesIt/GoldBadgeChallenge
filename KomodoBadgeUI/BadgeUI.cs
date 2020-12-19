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
        private BadgeRepo repoWindow = new BadgeRepo();


        public void Run()
        {
            loadData();
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
                        CreateNewBadge();
                        break;

                    case "2":
                        UpdateDoors();
                        break;

                    case "3":
                        DeleteAllDoors();
                        break;

                    case "4":
                        ShowEverything();
                        break;
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
            string doorInput;

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
                    doorInput = Console.ReadLine();
                    doorList.Remove(doorInput);
                    updateBadge.DoorNames = doorList;
                    repoWindow.UpdateDoors(tempInt, updateBadge);
                    break;
                case "2":
                    Console.WriteLine("Which door do you want to add? ");
                    doorInput = Console.ReadLine();
                    doorList.Add(doorInput);
                    updateBadge.DoorNames = doorList;
                    repoWindow.UpdateDoors(tempInt, updateBadge);
                    break;
                default:
                    break;
            }

        }

        private void DeleteAllDoors()
        {

            Badge updateBadge = new Badge();
            Console.WriteLine("What is the badge number? ");

            string userInput = Console.ReadLine();
            int tempInt = int.Parse(userInput);

            //retrieve the badge object using a repo function
            updateBadge = repoWindow.ReturnOneBadge(tempInt);

            //build a blank list of doors
            List<string> doorList = new List<string>();

            //update newbadge with the blank list of doors
            updateBadge.DoorNames = doorList;

            //use the repo to update the badge with the updated badge object
            repoWindow.UpdateDoors(tempInt, updateBadge);
        }
        private void ShowEverything()
        {
            string doorString = "";
            Dictionary<int, Badge> entireDictionary = new Dictionary<int, Badge>();
            entireDictionary = repoWindow.ShowEverything();
            foreach (KeyValuePair<int, Badge> item in entireDictionary)
            {
                doorString = "";

                foreach (string door in item.Value.DoorNames)
                {
                    doorString += door + ", ";
                }
                if (doorString.EndsWith(", "))
                {
                    doorString = doorString.Substring(0, doorString.Length - 2);
                }


                Console.WriteLine(item.Value.BadgeID.ToString()+ " - " + doorString);


            }

        }


        public void loadData()
        {
            List<string> doors1 = new List<string>();
            List<string> doors2 = new List<string>();
            List<string> doors3 = new List<string>();

            doors1.Add("A7");
            Badge B1 = new Badge(12345, doors1);          
            doors2.Add("A1");
            doors2.Add("A4");
            doors2.Add("B1");
            doors2.Add("B2");
            Badge B2 = new Badge(22345, doors2);
            doors3.Add("A4");
            doors3.Add("A5");
            Badge B3 = new Badge(32345, doors3);

            repoWindow._badgeDictionary.Add(12345, B1);
            repoWindow._badgeDictionary.Add(22345, B2);
            repoWindow._badgeDictionary.Add(32345, B3);


        }

    }
}




