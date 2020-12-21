using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repository
{
    public class CafeMenuRepository
    {
        private List<CafeMenu> _listOfMenuItems = new List<CafeMenu>();
        public void AddItemToList(CafeMenu item)
        {
            _listOfMenuItems.Add(item);
        }
        public List<CafeMenu> GetMenuList()
        {
            return _listOfMenuItems;
        }
        public bool UpdateExistingItem(string originalMealName, CafeMenu newItem)
        {
            CafeMenu oldItem = GetItemByMealName(originalMealName);
            if(oldItem != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.Description = newItem.Description;
                oldItem.Fixings = newItem.Fixings;
                oldItem.MealPrice = newItem.MealPrice;
                oldItem.IsGlutenFree = newItem.IsGlutenFree;
                oldItem.TypeOfMeat = newItem.TypeOfMeat;
                return true;
            }
            else
            {
                return false;
            }
        }
 
        //Delete
        public bool RemoveItemFromList(string mealName)
        {
            CafeMenu item = GetItemByMealName(mealName);
            if(item == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);

            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper methods
        public CafeMenu GetItemByMealName(string mealName)
        {
            foreach (CafeMenu item in _listOfMenuItems)
            {
                if(item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }
        public CafeMenu GetItemByMealNumber(int mealNumber)
        {
            foreach (CafeMenu item in _listOfMenuItems)
            {
                if(item.MealNumber == mealNumber)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
