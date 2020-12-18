using System;
using System.Collections.Generic;
using Repository_Challenge_Three;
using System.Text;

namespace Challenge_Three_Console
{
    class ProgramUI
    {
        private Badges_Repository _badgeRepo = new Badges_Repository();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu item:\n" +
                    "1. Create New Badge\n" +
                    "2. Update Door Access Of Existing Badge\n" +
                    "3. Delete Door Access Of Existing Badge\n" +
                    "4. View all badge numbers and door accesses\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                    {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        Console.WriteLine("Goodbye.");
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
        private void CreateNewBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();
            Console.WriteLine("Enter the new badge number(1200, 2400, etc.");
            string numberAsString = Console.ReadLine();
            newBadge.BadgeNumber = int.Parse(numberAsString);
            Console.WriteLine("Enter the door access for the new badge(a, c, e, etc.");
            newBadge.DoorAccess = Console.ReadLine();
            Console.WriteLine("Enter the Job Field number:\n" +
                "1. Claims\n" +
                "2. Development\n" +
                "3. Sales\n" +
                "4. Underwriting\n" +
                "5. Managerial");
            string jobAsString = Console.ReadLine();
            int jobAsInt = int.Parse(jobAsString);

            _badgeRepo.AddBadgeToList(newBadge);
            
        }
    }
}
