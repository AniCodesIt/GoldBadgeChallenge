using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04KomodoOutingsRepo
{
    public class POCO
    {
        public string EventType { get; set; }
        public int NumberofPeople { get; set; }
        public DateTime Date { get; set;}
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }

        public POCO(string eventType, int numberOfPeople, DateTime date, decimal costPerPerson, decimal costOfEvent)
        {
            EventType = eventType;
            NumberofPeople = numberOfPeople;
            Date = date;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }
        public POCO()
        {
        }
    }
    
}
