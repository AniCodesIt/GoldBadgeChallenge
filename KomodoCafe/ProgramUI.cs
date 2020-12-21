using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoCafeRepo;


namespace KomodoCafe
{
    class ProgramUI
    {
        MenuRepository menuRepository = new MenuRepository();
        public void RunMenu()
        {
            menuRepository.loaddata();


            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe App\n" +
                    "1. View the full menu\n" +
                    "2. Create a new menu item\n" +
                    "3. Delete an item from the menu\n" +
                    "20. Closes the program");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        getAllMenuItems();                      
                        break;
                    case "2":
                        CreateAMenuItem();
                        break;
                    case "3":
                        RemoveAMenuItem();
                        break;
                    case "20":
                        isRunning = false;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Hit 'Enter' to continue ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void RemoveAMenuItem()
        {
            Console.WriteLine("What is the meal number you want to remove? ");
            string stringMealNumber = Console.ReadLine();
            int intMealNumber = int.Parse(stringMealNumber);
            menuRepository.RemoveAMenuItem(intMealNumber);
        }

        private void CreateAMenuItem()
        {
            MenuDataModel newMenuItem = new MenuDataModel();
            Console.WriteLine("What is the meal number? ");
            string menuItem = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(menuItem);

            Console.WriteLine("What is the meal name? ");
            newMenuItem.MealName = Console.ReadLine();

            //asking the user for the description, shoving it into the description variable (through the newMenuItem "window")
            Console.WriteLine("What is the description for the meal? ");
            newMenuItem.Description = Console.ReadLine();

            List<string> ingredientEntry = new List<string>();
            string userEntry;
            Console.WriteLine("What are the ingredients? Enter the ingredients one at a time. Enter a blank line when done. ");
            do
            {
                userEntry = Console.ReadLine();
                if (userEntry != "")
                {
                    ingredientEntry.Add(userEntry);
                }
            }
            while (userEntry != "");
            newMenuItem.Ingredients = ingredientEntry;

            Console.WriteLine("What is the price? ");
            menuItem = Console.ReadLine();
            newMenuItem.Price = decimal.Parse(menuItem);

            menuRepository.CreateAMenuItem(newMenuItem);
        
        }

        private void getAllMenuItems()
        {
            List<string> thisIngredients = new List<string>();
            string returnString = "";
            string IngredientsString = "";
            //need a method to pull the list of menu items from the repository

            List<MenuDataModel> menuReturn = menuRepository.GetAllMenuItems();

            foreach (MenuDataModel Snacks in menuReturn)
            {
                returnString += Snacks.MealNumber + ": " +
                                Snacks.MealName + " - " +
                                Snacks.Description + " " +
                                //Snacks.Ingredients + " " +
                                "$ " + Snacks.Price.ToString();
                returnString += "\n    ";

                thisIngredients = Snacks.Ingredients;

                IngredientsString = "";
                foreach (string thisString in thisIngredients)
                {
                    IngredientsString += thisString + ", ";
                }
                returnString += IngredientsString;
                returnString += "\n";
            }
            Console.WriteLine(returnString);
        }
        public void loaddata()
        {
            List<string> s1 = new List<string>();

            s1.Add("Chicken");
            s1.Add("Bell Peppers");
            s1.Add("Onions");
            s1.Add("Red Hot Sauce");
            MenuDataModel m1 = new MenuDataModel(1, "Szechuan Chicken", "Hot spicy chicken with hot red sauce and veggies", s1, decimal.Parse("12.95"));

            s1.Clear();
            s1.Add("Eggs");
            s1.Add("Foo");
            s1.Add("Young");
            MenuDataModel m2 = new MenuDataModel(2, "Egg Foo Yung", "An Asian omelette with vegetables", s1, decimal.Parse("13.50"));

            s1.Clear();
            s1.Add("Beef Broth");
            s1.Add("Green Onions");
            s1.Add("Wontons");
            s1.Add("Hot Oil");
            MenuDataModel m3 = new MenuDataModel(3, "Wonton Soup", "Beef broth with onions and Asian dumplings.", s1, decimal.Parse("7.25"));

            s1.Clear();
            s1.Add("Beef");
            s1.Add("Onions");
            s1.Add("Brown Sauce");
            s1.Add("Steamed Rice");
            s1.Add("Brown Sauce");
            MenuDataModel m4 = new MenuDataModel(4, "Mongolian Beef", "Beef with onions and brown sauce over rice", s1, decimal.Parse("15.99"));

            s1.Clear();
            s1.Add("Cabbage");
            s1.Add("Carrots");
            s1.Add("Onions");
            s1.Add("Wonton wrap");
            s1.Add("Scallions");
            MenuDataModel m5 = new MenuDataModel(5, "Spring Roll", "Vegetables rolled in wonton wrap and deep fried", s1, decimal.Parse("4.99"));

            menuRepository.FullListOfMenuItems.Add(m1);
            menuRepository.FullListOfMenuItems.Add(m2);
            menuRepository.FullListOfMenuItems.Add(m3); 
            menuRepository.FullListOfMenuItems.Add(m4);
            menuRepository.FullListOfMenuItems.Add(m5);           

        }
    }

}
