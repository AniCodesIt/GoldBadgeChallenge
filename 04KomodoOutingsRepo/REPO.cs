using _04KomodoOutingsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsRepo 
{ 


    public class REPO
    {
        //list of outings
        public List<POCO> ListOfOutings = new List<POCO>();

        //method to return the list to the UI
        // return outings;
        public List<POCO> ReturnListOfEvents()
        {
            return ListOfOutings;
        }

        //add to the list of outings (spring event, holiday party)
       // List.add
       public void AddAnOuting(POCO newOuting)
        {
            ListOfOutings.Add(newOuting);
        }  

    }
}
