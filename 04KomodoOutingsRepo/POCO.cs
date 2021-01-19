using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04KomodoOutingsRepo
{
    public class POCO
    {
        public Events EventType { get; set; }
        public int NumberofPeople { get; set; }
        public DateTime Date { get; set;}
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }

        public POCO(int eventType, int numberOfPeople, DateTime date, decimal costPerPerson, decimal costOfEvent)
        {
            EventType = (Events)eventType;
            NumberofPeople = numberOfPeople;
            Date = date;
            CostPerPerson = (decimal)costPerPerson;
            CostOfEvent = (decimal)costOfEvent;
        }
        public POCO(int eventType, int numberOfPeople, DateTime date, double costPerPerson)
        {
            EventType = (Events)eventType;
            NumberofPeople = numberOfPeople;
            Date = date;
            CostPerPerson = (decimal)costPerPerson;
            CostOfEvent = numberOfPeople * (decimal)costPerPerson;
        }
        public POCO()
        {
        }
        public enum Events
        {
            Golf = 1, 
            Bowling, 
            Amusement_Park, 
            Concert
        }
    }

    
}
