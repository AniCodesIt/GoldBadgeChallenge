using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KomodoCafeRepo
{
    public class MenuRepository
    {
        public List<MenuDataModel> FullListOfMenuItems = new List<MenuDataModel>();
      
        public void CreateAMenuItem(MenuDataModel newMenuItem)
        {
           
            FullListOfMenuItems.Add(newMenuItem);

        }
      
        public List<MenuDataModel> GetAllMenuItems()
        {         
            return FullListOfMenuItems;
        }

        public void RemoveAMenuItem(int intMealNumber)
        {
            int index = 0;
            foreach (MenuDataModel menuItem in FullListOfMenuItems)
            {
                if (menuItem.MealNumber == intMealNumber)
                {
                    FullListOfMenuItems.RemoveAt(index);
                    break;
                }
                index++;
            }
           
        }

       
    }
}
