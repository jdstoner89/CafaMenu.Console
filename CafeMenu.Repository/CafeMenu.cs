using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repository
{
    public enum MeatType
    {
        Beef = 1,
        Tuna,
        Pork,
        Ham,
        Turkey,
    }
    public class CafeMenu
    {
        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string Description { get; set; }
        public string Fixings { get; set; }
        public double MealPrice { get; set; }
        public bool IsGlutenFree { get; set; }
        public MeatType TypeOfMeat { get; set; }
        public CafeMenu() { }
        public CafeMenu(string mealName, int mealNumber, string description, string fixings, double mealPrice, bool isGlutenFree, MeatType meat)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Fixings = fixings;
            MealPrice = mealPrice;
            IsGlutenFree = isGlutenFree;
            TypeOfMeat = meat;
        }
    }
}
