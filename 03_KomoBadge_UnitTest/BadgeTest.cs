using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_BadgeRepository;
using System.Collections.Generic;

namespace _03_KomoBadge_UnitTest
{
    [TestClass]
    public class BadgeTest
    {
        BadgeRepo repoWindow = new BadgeRepo();
        

        [TestMethod]
        public void CreateNewBadgeTest()
        {
            loadData();
            List<string> doors4 = new List<string>();

            doors4.Add("A1");
            doors4.Add("A5");
            doors4.Add("B5");
            doors4.Add("B7");
            Badge B4 = new Badge(52345, doors4);
            int initialCount = repoWindow._badgeDictionary.Count;
            repoWindow.CreateNewBadge(52345, B4);
            int secondCount = repoWindow._badgeDictionary.Count;
            Assert.AreEqual(secondCount, initialCount + 1);
        }
        [TestMethod]      
        public void UpdateDoorsTest()
        {
            loadData();
            //we will need a list of a few doors to create a new badge
            List<string> doors4 = new List<string>();

            doors4.Add("A1");
            doors4.Add("A5");
            doors4.Add("B5");
            doors4.Add("B7");
            //Creates  a new badge
            Badge B4 = new Badge(52345, doors4);
            //Adds the new badge to the dictionary
            repoWindow._badgeDictionary.Add(52345, B4);

            //add a door to our temp list of doors
            doors4.Add("B3");
            //updates the badge we already created with the new list of doors (this is not the badge in the dictionary ,it's 
            //just a temp that we're using)
            B4.DoorNames = doors4;
            //using the repo method that we're testing, update badge number 52345 with the temp badge we updated above
            repoWindow.UpdateDoors(52345, B4);
            //Now go to the dictoinary and pull the (updated) badge out into ANOTHER badge object.
            Badge resultBadge = repoWindow._badgeDictionary[52345];
            //Grabe the list of doors out of the ANOTHER badge object into ANOTHER list of doors.
            List<string> resultDoorList = resultBadge.DoorNames;
            //Get the number of doors in the ANOTHER list.
            int resultDoorCount = resultDoorList.Count; // should be 5
            Assert.AreEqual(5, resultDoorList.Count);

            




            //create a brand new badge
            //add the badge to the dictionary
            //in the badge we already had created, add another door to the list
            //run UpdateDoors inputting the newBadge again (with the updated list of doors)
            //check the result


            //
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








