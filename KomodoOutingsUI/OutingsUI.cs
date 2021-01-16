﻿using _04KomodoOutingsRepo;
using KomodoOutingsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsUI
{

    public class OutingsUI
    {
        REPO repoWindow = new REPO();
        public void RunMenu()
        {
            //TODO
            // loaddata();


            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Event Page\n" +
                    "1. View the full list of events\n" +
                    "2. Create a new event\n" +
                    "3. See the total cost of all events\n" +
                    "4. See the total cost events by activity\n" +
                    "20. Closes the program");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewListOfEvents();
                        break;
                    case "2":
                        AddAnOuting();
                        break;
                    case "3":
                        CostOfAllEvents();
                        break;
                    case "4":
                        CostOfEventByType();
                        break;
                    case "20":
                        isRunning = false;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Hit 'Enter' to continue ");
                Console.ReadLine();               
            }
        }


        //list of outings
        private void ViewListOfEvents()
        {
            List<POCO> events = repoWindow.ReturnListOfEvents();
            string returnString = "";

            foreach (var item in events)
            {
                returnString += item.EventType + ": " +
                              item.NumberofPeople + " - " +
                              item.Date.ToString() + " " +
                              "$ " + item.CostPerPerson.ToString() +
                              "$ " + item.CostOfEvent.ToString();

                returnString += "\n    ";
                Console.WriteLine();
            }
        }


        private void AddAnOuting()
        {
            POCO outing = new POCO();

            Console.WriteLine("What type of event? ");
            string eventType = Console.ReadLine();

            Console.WriteLine("How many people will be there? ");
            string numberOfPeople = Console.ReadLine();

            Console.WriteLine("What date will it be? ");
            string date = Console.ReadLine();

            Console.WriteLine("What is the cost per person? ");
            string costPerPerson = Console.ReadLine();

            decimal eventCost = int.Parse(numberOfPeople) * decimal.Parse(costPerPerson);

            outing.EventType = eventType;
            outing.NumberofPeople = int.Parse(numberOfPeople);
            outing.Date = DateTime.Parse(date);
            outing.CostPerPerson = decimal.Parse(costPerPerson);
            outing.CostOfEvent = eventCost;

            repoWindow.AddAnOuting(outing);
        }
        private void CostOfAllEvents()
        {
            List<POCO> tempVar = repoWindow.ReturnListOfEvents();
            decimal total = 0;
            foreach (var item in tempVar)
            {
                total = total + item.CostOfEvent;
            }
            Console.WriteLine("The total cost of events is $ " + total);

        }

        private void CostOfEventByType()
        { 
            List<POCO> tempVar = repoWindow.ReturnListOfEvents();
            Console.WriteLine("Which event type do you want to total? ");
            string eventType = Console.ReadLine();
            decimal total = 0;
            foreach (var item in tempVar)
            {
                if (item.EventType == eventType)
                {
                    total = total + item.CostOfEvent;
                }

            }
            Console.WriteLine("The total cost of" + eventType +" is $ " + total);

        }

    }
       
}
