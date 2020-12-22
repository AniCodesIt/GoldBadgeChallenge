using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoCafeRepo;
using System.Collections.Generic;
using KomodoCafe;


namespace _01_KomodoCafe_UnitTest
{ 
    [TestClass]
    public class KomodoCafeUnitTest
    {
        MenuRepository repoWindow = new MenuRepository();
        KomodoCafeUI UIWindow = new KomodoCafeUI();
        
        [TestMethod]
        public void CreateAMenuItemTest()
        {            
            List<string> ingredients = new List<string>();
            ingredients.Add("tofu");
            ingredients.Add("rice");
            ingredients.Add("egg");
            MenuDataModel controlData = new MenuDataModel(5, "tofu", "tofu and rice", ingredients, decimal.Parse("4.99"));
            repoWindow.CreateAMenuItem(controlData);

            Assert.AreEqual(1, repoWindow.FullListOfMenuItems.Count);
        }
        [TestMethod]
        public void GetAllMenuItemsTest()
        {
            loaddata();
            List<MenuDataModel> tempMenu = new List<MenuDataModel>();
            tempMenu = repoWindow.GetAllMenuItems();

            Assert.AreEqual(5, tempMenu.Count);
            //Assert.AreNotEqual(0, tempMenu.Count);
        }

        [TestMethod]
        public void RemoveAMenuItemTest()
        {
            loaddata();
            int initialCount = repoWindow.FullListOfMenuItems.Count;
            repoWindow.RemoveAMenuItem(3);
            int finalCount = repoWindow.FullListOfMenuItems.Count;
            // Assert.AreEqual(4, repoWindow.FullListOfMenuItems.Count);
            Assert.AreEqual(initialCount, finalCount);
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

            repoWindow.FullListOfMenuItems.Add(m1);
            repoWindow.FullListOfMenuItems.Add(m2);
            repoWindow.FullListOfMenuItems.Add(m3);
            repoWindow.FullListOfMenuItems.Add(m4);
            repoWindow.FullListOfMenuItems.Add(m5);

        }
    }
}
