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

        public void LoadData()
        {
            POCO a = new POCO(2, 3, DateTime.Parse("	2019-07-31	"), 50.98);
            POCO b = new POCO(1, 5, DateTime.Parse("	2019-12-24	"), 81.48);
            POCO c = new POCO(1, 8, DateTime.Parse("	2019-09-12	"), 15.61);
            POCO d = new POCO(2, 12, DateTime.Parse("	2019-05-03	"), 13.68);
            POCO e = new POCO(4, 4, DateTime.Parse("	2019-04-24	"), 63.4);
            POCO f = new POCO(3, 11, DateTime.Parse("	2019-05-24	"), 43.04);
            POCO g = new POCO(1, 2, DateTime.Parse("	2019-11-30	"), 7.04);
            POCO h = new POCO(1, 3, DateTime.Parse("	2019-03-24	"), 25.49);
            POCO i = new POCO(2, 9, DateTime.Parse("	2019-05-26	"), 83.75);
            POCO j = new POCO(2, 1, DateTime.Parse("	2019-01-03	"), 51.55);
            POCO k = new POCO(4, 12, DateTime.Parse("	2019-07-13	"), 17.59);
            POCO l = new POCO(4, 1, DateTime.Parse("	2019-03-30	"), 40.77);
            POCO m = new POCO(2, 10, DateTime.Parse("	2019-10-27	"), 53.85);
            POCO n = new POCO(3, 5, DateTime.Parse("	2019-01-21	"), 0.21);
            POCO o = new POCO(1, 7, DateTime.Parse("	2019-02-14	"), 31.73);
            POCO p = new POCO(2, 10, DateTime.Parse("	2019-04-07	"), 19.69);
            POCO q = new POCO(4, 6, DateTime.Parse("	2019-03-20	"), 15.48);


            ListOfOutings.Add(a);
            ListOfOutings.Add(b);
            ListOfOutings.Add(c);
            ListOfOutings.Add(d);
            ListOfOutings.Add(e);
            ListOfOutings.Add(f);
            ListOfOutings.Add(h);
            ListOfOutings.Add(i);
            ListOfOutings.Add(j);
            ListOfOutings.Add(k);
            ListOfOutings.Add(l);
            ListOfOutings.Add(m);
            ListOfOutings.Add(n);
            ListOfOutings.Add(o);
            ListOfOutings.Add(p);
            ListOfOutings.Add(q);

        }
    }
}
