using System;
using Challenge_One_Repository;
using System.Collections.Generic;
using System.Text;

namespace Challenge_One_Console
{
    class ProgramUI
    {
        private CafeMenuRepository _itemRepo = new CafeMenuRepository();
        public void Run()
        {
            SeedItemList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu item:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View Menu Items By Meal Name\n" +
                    "4. View Menu Items By Meal Number\n" +
                    "5. Update Existing Menu Items\n" +
                    "6. Delete Existing Menu Items\n" +
                    "7. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        ViewMenuItemsByMealName();
                        break;
                    case "4":
                        ViewMenuItemsByMealNumber();
                        break;
                    case "5":
                        UpdateExistingMenuItem();
                        break;
                    case "6":
                        DeleteExistingMenuItem();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            CafeMenu newItem = new CafeMenu();

            Console.WriteLine("Enter the name of the meal:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal's menu number:");
            string numberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the description of the meal:");
            newItem.Description = Console.ReadLine();
            
            Console.WriteLine("Enter the fixings/ingredients of the meal:");
            newItem.Fixings = Console.ReadLine();
            
            Console.WriteLine("Enter the price of the meal (9.99, 14.50, etc.):");
            string priceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(priceAsString);
            
            Console.WriteLine("Is this meal gluten free?");
            string glutenFreeString = Console.ReadLine().ToLower();
            if(glutenFreeString == "y")
            {
                newItem.IsGlutenFree = true;
            }
            else
            {
                newItem.IsGlutenFree = false;
            }
            
            Console.WriteLine("Enter the Meat Type Number:\n" +
                "1. Beef\n" +
                "2. Tuna\n" +
                "3. Pork\n" +
                "4. Ham\n" +
                "5. Turkey");
            string meatAsString = Console.ReadLine();
            int meatAsInt = int.Parse(meatAsString);
            newItem.TypeOfMeat = (MeatType)meatAsInt;

            _itemRepo.AddItemToList(newItem);
        }
        private void ViewAllMenuItems()
        {
            List<CafeMenu> listOfItems = _itemRepo.GetMenuList();
            foreach(CafeMenu item in listOfItems)
            {
                Console.WriteLine($"MealName: {item.MealName}\n" +
                    $"MealNumber: {item.MealNumber}\n" +
                    $"Description: {item.Description}");
            }
        }
        private void ViewMenuItemsByMealName()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the meal you are looking for:");
            
            string mealName = Console.ReadLine();
            
            CafeMenu item = _itemRepo.GetItemByMealName(mealName);
            
            if (item != null)
            {
                Console.WriteLine($"MealName: {item.MealName}\n" +
                    $"MealNumber: {item.MealNumber}\n" +
                    $"Description: {item.Description}\n" +
                    $"Fixings: {item.Fixings}\n" +
                    $"MealPrice: {item.MealPrice}\n" +
                    $"IsGlutenFree: {item.IsGlutenFree}\n" +
                    $"MeatType: {item.TypeOfMeat}");
            }
            else
            {
                Console.WriteLine("No meal by that name.");
            }
        }
      
        private void ViewMenuItemsByMealNumber()
        {

        }
        
        private void UpdateExistingMenuItem()
        {

            
            ViewAllMenuItems();
           
            Console.WriteLine("Enter the name of the menu item you want to update.");
            
            string oldMealName = Console.ReadLine();
            

            Console.Clear();
            CafeMenu newItem = new CafeMenu();
            
            Console.WriteLine("Enter the name of the meal:");
            newItem.MealName = Console.ReadLine();
            
            Console.WriteLine("Enter the meal's menu number:");
            string numberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(numberAsString);
            
            Console.WriteLine("Enter the description of the meal:");
            newItem.Description = Console.ReadLine();
            
            Console.WriteLine("Enter the fixings/ingredients of the meal:");
            newItem.Fixings = Console.ReadLine();
            
            Console.WriteLine("Enter the price of the meal (9.99, 14.50, etc.):");
            string priceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(priceAsString);
            
            Console.WriteLine("Is this meal gluten free?");
            string glutenFreeString = Console.ReadLine().ToLower();
            if (glutenFreeString == "y")
            {
                newItem.IsGlutenFree = true;
            }
            else
            {
                newItem.IsGlutenFree = false;
            }
            
            Console.WriteLine("Enter the Meat Type Number:\n" +
                "1. Beef\n" +
                "2. Tuna\n" +
                "3. Pork\n" +
                "4. Ham\n" +
                "5. Turkey");
            string meatAsString = Console.ReadLine();
            int meatAsInt = int.Parse(meatAsString);
            newItem.TypeOfMeat = (MeatType)meatAsInt;
            
            bool wasUpdated = _itemRepo.UpdateExistingItem(oldMealName, newItem);

            if(wasUpdated)
            {
                Console.WriteLine("Menu item successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update menu item.");
            }
        }
        
        private void DeleteExistingMenuItem()
        {
            Console.Clear();
            ViewAllMenuItems();
            
            Console.WriteLine("\nEnter the name of the menu item you want deleted:");
            string input = Console.ReadLine();
            
            bool wasDeleted = _itemRepo.RemoveItemFromList(input);
            
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }
            
        }
        
        
        private void SeedItemList()
        {
            CafeMenu cheeseburger = new CafeMenu("Cheeseburger", 1, "Classic American cheeseburger.", "Half-pound Angus beef patty with American cheese on a toasted bun", 9.99, false, MeatType.Beef);
            CafeMenu tunaMelt = new CafeMenu("Tuna Melt", 2, "Our Award-Winning Tuna Melt.", "Local farm-raised Albacore Tuna mixed with mayo and dijon mustard on a wheat bun", 12.50, false, MeatType.Tuna);
            CafeMenu cuban = new CafeMenu("Cuban", 3, "Our twist on the classic Cuban sandwich.", "Slow-cooked pork shoulder thinly sliced with swiss cheese thinly sliced pickles and yellow mustard on our made-from-scratch hoagie bun.", 14.99, false,  MeatType.Pork);
            CafeMenu hamAndCheeseMelt = new CafeMenu("Ham and Cheese Melt", 4, "The Classic Grilled Cheese with a ham upgrade!", "Fresh and thinly sliced ham with extra American cheese on white toast.", 7.95, false, MeatType.Ham);
            CafeMenu turkeyClub = new CafeMenu("Turkey Club", 5, "A healthy and refreshing Turkey Club Sandwich.", "Fresh and thinly sliced turkey with lettuce tomato and dijon mustard on wheat toast", 9.99, false, MeatType.Turkey);

            _itemRepo.AddItemToList(cheeseburger);
            _itemRepo.AddItemToList(tunaMelt);
            _itemRepo.AddItemToList(cuban);
            _itemRepo.AddItemToList(hamAndCheeseMelt);
            _itemRepo.AddItemToList(turkeyClub);
        }
    }   
}
