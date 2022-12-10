using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

/* Course Work - Realize Organic Market application system using C# principles 
          
   Contains such principles:
     - Polymorphism using virtual and override methods;
     - Abstract class and system interface usage;
     - Collection usage (lists);
     - Usage of delegates as parameter;
     - Serialization/deserialization using binary approach.

   Program gives access to such commands:
     - Browsing Organic Market collections using Menu commands;
     - Adding new Grocery/Dairy products;
     - Ability to find/delete/sort Grocery/Dairy products;
     - Possibility of reducing/increasing total amount of products stored;
     - Saving and loading Organic Market class as a bin application.
 */

namespace Course_Work_Supermarket
{
    // menu program class
    public class Menu
    {
        public OrganicMarket market;

        // serialization components
        public const string file = "OrganicMarket.txt";
        BinaryFormatter bin = new BinaryFormatter();

        // menu methods
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* - * - * - * - WELCOME TO ORGANIC MARKET MANAGER APP - * - * - * - *\n");
            Console.ResetColor();
            Console.WriteLine("Please choose the operation from the list: " +
                "\n * [1] Show all available products in the database *\n * [2] Add new green product *" +
                "\n * [3] Add new dairy product *\n * [4] Find a grocery product *" +
                "\n * [5] Find a dairy product *\n * [6] Delete a grocery product *" +
                "\n * [7] Delete a dairy product *\n * [8] Save database to the file *" +
                "\n * [9] Load data *\n * [10] Decrease total amount of goods *" +
                "\n * [11] Increase total amount of goods *");
        }
        public void ProgramShow()
        {
            Console.WriteLine("You've chosen option 1!");
            market.ShowAll();
        }

        public void ProgramAddG()
        {
            Console.WriteLine("Please enter the info about your new grocery product in such order" +
                "\n Name -> ");
            string nameInfo = Console.ReadLine();
            Console.WriteLine("Price -> ");
            int priceInfo = Console.Read();
            Console.WriteLine("Expiration Date -> ");
            double expirationInfo = Console.Read();
            Console.WriteLine("Amount -> ");
            int amountInfo = Console.Read();
            Console.WriteLine("Category [ Vegetables, Fruit, Herbs ]:");
            var category = Console.ReadLine();

            market.AddGrocery(nameInfo, priceInfo, expirationInfo, amountInfo, category);
        }

        public void ProgramAddD()
        {
            Console.WriteLine("Please enter the info about your new grocery product in such order" +
                "\n Name -> ");
            string nameInfo = Console.ReadLine();
            Console.WriteLine("Price -> ");
            int priceInfo = Console.Read();
            Console.WriteLine("Expiration Date -> ");
            double expirationInfo = Console.Read();
            Console.WriteLine("Amount -> ");
            int amountInfo = Console.Read();
            Console.WriteLine("Category [ Cheese, MilkProduct, IceCream ]: ");
            string category = Console.ReadLine();

            market.AddDairy(nameInfo, priceInfo, expirationInfo, amountInfo, category);
        }

        public void ProgramFindG()
        {
            Console.WriteLine("Enter the name of the product you want to find: ");
            string name = Console.ReadLine();

            market.FindGrocery(name);
        }

        public void ProgramFindD()
        {
            Console.WriteLine("Enter the name of the product you want to find: ");
            string name = Console.ReadLine();

            market.FindDairy(name);
        }

        public void ProgramDeleteG()
        {
            Console.WriteLine("Please enter the name of the green product you want to delete from the database: ");
            string name = Console.ReadLine();

            market.DeleteGrocery(name);
        }

        public void ProgramDeleteD()
        {
            Console.WriteLine("Please enter the name of the dairy product you want to delete from the database: ");
            string name = Console.ReadLine();

            market.DeleteDairy(name);
        }

        public void ProgramSave()
        {
            try
            {
                using (Stream fStream = File.Create("OrganicMarket.bin"))
                {
                    bin.Serialize(fStream, market);
                }
                Console.WriteLine("Saving is completed!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ProgramLoad()
        {
            try
            {
                List<OrganicMarket> market = null;
                using (Stream fStream = File.OpenRead("OrganicMarket.bin"))
                {
                    market = (List<OrganicMarket>)bin.Deserialize(fStream);
                }
                foreach (OrganicMarket item in market)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ProgramDecrease()
        {
            Console.WriteLine("Your amount is going to be decreased due to inflation.");
            market.Change(market.TotalAmount, market.Shortage);
        }

        public void ProgramIncrease()
        {
            Console.WriteLine("Your amount is going to be decreased due to inflation.");
            market.Change(market.TotalAmount, market.Supply);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // initialize program
            OrganicMarket market = new OrganicMarket("Green Life", "St. Peter Street, 12");
            Menu menu = new Menu();
            menu.ShowMenu();

            Console.WriteLine("\nEnter your option below from 1 to 11 :");
            int option = Console.Read();
            switch (option)
            {
                case 1:
                    menu.ProgramShow();
                    break;
                case 2:
                    menu.ProgramAddG();
                    break;
                case 3:
                    menu.ProgramAddD();
                    break;
                case 4:
                    menu.ProgramFindG();
                    break;
                case 5:
                    menu.ProgramFindD();
                    break;
                case 6:
                    menu.ProgramDeleteG();
                    break;
                case 7:
                    menu.ProgramDeleteD();
                    break;
                case 8:
                    menu.ProgramSave();
                    break;
                case 9:
                    menu.ProgramLoad();
                    break;
                case 10:
                    menu.ProgramDecrease();
                    break;
                case 11:
                    menu.ProgramIncrease();
                    break;
                default:
                    break;
            }
        }
    }
}
