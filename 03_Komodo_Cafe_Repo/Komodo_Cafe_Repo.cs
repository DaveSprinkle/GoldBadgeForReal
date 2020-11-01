using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Cafe_Repo
{
    public class Komodo_Cafe_Repo
    {
        List<KMenuItem> _meal = new List<KMenuItem>();

        public bool AddMenuItemToList(KMenuItem item)
        {
            int startingCount = _meal.Count;
            _meal.Add(item);

            bool wasAdded = (_meal.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<KMenuItem> GetItems()
        {
            return _meal;
        }

        public KMenuItem GetItemByName(string itemname)
        {
            foreach (KMenuItem menuItem in _meal)
            {
                if (menuItem.MealName.ToLower() == itemname.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }

        public bool UpdateExistingItem(string originalItem, KMenuItem newItem)
        {
            KMenuItem item = GetItemByName(originalItem);

            if (item != null)
            {
                item.MealName = newItem.MealName;
                item.MealDescription = newItem.MealDescription;
                item.MealIngredients = newItem.MealIngredients;
                item.MealPrice = newItem.MealPrice;
                
                return true;
            }
            else { return false; }
        }


        public bool DeleteItem(KMenuItem item)
        {
            int startingCount = _meal.Count;
            _meal.Remove(item);

            bool wasDeleted = (_meal.Count < startingCount) ? true : false;
            return wasDeleted;
        }
















    }
}
