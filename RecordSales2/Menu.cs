using System;
using System.Collections.Generic;
using System.Text;

namespace RecordSales2
{
    class Menu

    {
        static string[] drinkNames = new string[10];
        static int[] drinkSales = new int[10];
        //static int exit = 4;


        public static void ShowMenu()
        {

            Console.WriteLine("Main menu");
            Console.WriteLine("1. Add a new drink.");
            Console.WriteLine("2. Edit a drink.");
            Console.WriteLine("3. List all the drinks.");
            Console.WriteLine("4. Exit.");
            Console.WriteLine("Make a selection from 1-4.");


        }
        public static void UserChoice()
        {
            char exit = '4';
            char userInput;
            do
            {
                Console.Clear();
                ShowMenu();
                userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        AddDrink();
                        break;
                    case '2':
                        EditDrink();
                        break;
                    case '3':
                        ListDrinks();
                        break;
                    case '4':
                        Console.Clear();
                        userInput = exit;
                        Console.WriteLine("Thank you! Bye!");
                        break;

                }

            } while (userInput != exit);



        }
        public static void AddDrink()
        {
            Console.Clear();
            string drinkNameInput;
            string drinkSaleInput;
            int drinkCopySales;

            Console.WriteLine("Enter the drink name.");
            drinkNameInput = Console.ReadLine();
            Console.WriteLine("How many of these drinks did you sell?");
            drinkSaleInput = Console.ReadLine();
            //Int32.TryParse(Console.ReadLine(), out drinkCopySales);
            drinkCopySales = Convert.ToInt32(drinkSaleInput);


            int nextAvailableSlot = FindSlot("");
            if (nextAvailableSlot != -1)
            {
                drinkNames[nextAvailableSlot] = drinkNameInput;
                drinkSales[nextAvailableSlot] = drinkCopySales;
            }
            else
            {
                Console.WriteLine("No more space!");
            }


        }

        public static void EditDrink()
        {
            Console.Clear();
            int newDrinkSale;
            int identifyDrink;
            string userInput;

            Console.WriteLine("Please enter the name of the drink you want to edit.");
            userInput = Console.ReadLine();
            identifyDrink = FindSlot(userInput);

            if (identifyDrink != -1)
            {
                Console.WriteLine("Please enter the new sale number.");
                Int32.TryParse(Console.ReadLine(), out newDrinkSale);
                //newDrinkSale = Convert.ToInt32(Console.ReadLine());
                drinkSales[identifyDrink] = newDrinkSale;

            }
            else
            {
                Console.WriteLine("The drink {0} could not be found!", userInput);
            }


        }

        static void ListDrinks()
        {
            Console.Clear();
            for (int i = 0; i < drinkNames.Length; i++)
            {
                if (drinkNames[i] != "" && drinkNames[i] != null)
                {
                    Console.WriteLine("The drink {0} has been sold {1} times.", drinkNames[i], drinkSales[i]);

                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();


        }

        static int FindSlot(string drinkName)
        {
            int result = -1;
            for (int i = 0; i < drinkNames.Length; i++)
            {
                if (drinkNames[i] == drinkName)
                {
                    result = i;
                    break;
                }
                else if (drinkName == "" && drinkNames[i] == null)
                {
                    result = i;
                    break;
                }

            }
            return result;

        }
        

    }
}
