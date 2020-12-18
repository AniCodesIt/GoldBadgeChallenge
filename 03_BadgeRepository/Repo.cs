using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class Repo
    {
        public Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        //create a new badge

        public void CreateNewBadge(int BadgeID, Badge newBadge)
        {
            _badgeDictionary.Add(BadgeID, newBadge);            
        }

        //update doors on an existing badge.

        public void UpdateDoors(int BadgeID, Badge newBadge)
        {
            _badgeDictionary[BadgeID] = newBadge;               
        }
	 //delete all doors from an existing badge.

        public void DeleteAllDoors(int BadgeID)
        {
            _badgeDictionary.Remove(BadgeID);
            Badge blankBadge = new Badge(BadgeID);
            _badgeDictionary.Add(BadgeID, blankBadge);
        }
        //show a list with all badge numbers and door access
        public Dictionary<int, Badge> ShowEverything()
        {
           return _badgeDictionary;
        }

        public Badge ReturnOneBadge(int BadgeID)
        {        
                return _badgeDictionary[BadgeID];
        }
        

    }
}
