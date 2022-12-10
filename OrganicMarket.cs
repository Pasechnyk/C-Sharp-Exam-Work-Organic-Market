using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Course_Work_Supermarket
{
    // declare delegate
    public delegate void ChangeAmount(int value);

    [Serializable]
    public class OrganicMarket
    {
        // auto and list properties
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Greens> groceries { get; set; }
        public List<Dairy> dairies { get; set; }

        // complex property
        public int TotalAmount => groceries.Count + dairies.Count;

        // constructors
        public OrganicMarket(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public OrganicMarket(string name, string address, 
            List<Greens> groceries, List<Dairy> dairies) : this(name, address)
        {
            // populating lists
            groceries = new List<Greens>()
            {
                new Greens("Cucumber", 5, 20.05, 60, GreenCategory.Vegetable),
                new Greens("Tomato", 5, 21.05, 80, GreenCategory.Vegetable),
                new Greens("Carrot", 4, 20.05, 78, GreenCategory.Vegetable),
                new Greens("Letuce", 2, 18.05, 65, GreenCategory.Vegetable),

                new Greens("Apple", 3, 28.05, 150, GreenCategory.Fruit),
                new Greens("Banana", 4, 26.05, 130, GreenCategory.Fruit),
                new Greens("Pear", 3, 28.05, 94, GreenCategory.Fruit),
                new Greens("Mango", 6, 29.05, 43, GreenCategory.Fruit),

                new Greens("Basil", 1, 27.11, 30, GreenCategory.Herbs),
                new Greens("Rosemary", 1, 14.11, 34, GreenCategory.Herbs),
                new Greens("Mint", 1, 18.10, 52, GreenCategory.Herbs),
                new Greens("Oregano", 1, 27.11, 30, GreenCategory.Herbs),
            };
            dairies = new List<Dairy>()
            {
                new Dairy("Coconut Milk", 12, 06.09, 80, DairyCategory.MilkProduct),
                new Dairy("Wheat Milk", 11, 08.09, 67, DairyCategory.MilkProduct),
                new Dairy("Standart Milk", 8, 15.11, 110, DairyCategory.MilkProduct),
                new Dairy("Oat Milk", 12, 07.09, 49, DairyCategory.MilkProduct),

                new Dairy("Brie", 18, 08.10, 24, DairyCategory.Cheese),
                new Dairy("Blue", 16, 09.10, 38, DairyCategory.Cheese),
                new Dairy("Cheddar", 21, 11.12, 46, DairyCategory.Cheese),
                new Dairy("Gouda", 17, 02.11, 19, DairyCategory.Cheese),

                new Dairy("Strawberry Ice Cream", 12, 07.12, 15, DairyCategory.IceCream),
                new Dairy("Vanilla Ice Cream", 10, 07.12, 23, DairyCategory.IceCream),
                new Dairy("Blueberry Ice Cream", 11, 08.12, 20, DairyCategory.IceCream),
                new Dairy("Strawberry Ice Cream", 42, 07.12, 15, DairyCategory.IceCream),
            };
        }

        // list methods
        public void ShowAll()
        {
            Console.WriteLine("Available departments and their content:");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n-------------- Green Department --------------");
            Console.ResetColor();
            foreach (var grocery in groceries)
            {
                Console.WriteLine($"Name of the grocery product - {grocery.Name} \n Price - {grocery.Price} " +
                    $"\n Expiration date - {grocery.ExpirationTime}" +
                        $"\n Amount left - {grocery.Amount}");
                Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - ");
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n-------------- Dairy Department --------------");
            Console.ResetColor();
            foreach (var dairy in dairies)
            {
                Console.WriteLine($"Name of the dairy product - {dairy.Name} \n Price - {dairy.Price} " +
                    $"\n Expiration date - {dairy.ExpirationTime}" +
                        $"\n Amount left - {dairy.Amount}");
                Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - ");
            }
        }
        public void AddGrocery(string name, decimal price, double expiration, int amount, GreenCategory type)
        {
            groceries.Add(new Greens(name, price, expiration, amount, type));
        }
        public void AddDairy(string name, decimal price, double expiration, int amount, DairyCategory type)
        {
            dairies.Add(new Dairy(name, price, expiration, amount, type));
        }

        public void FindGrocery(string name)
        {
            foreach(var grocery in groceries)
            {
                if(grocery.Name == name)
                {
                    Console.WriteLine("Your product is available in this database! \n Here's information about it:");
                    Console.WriteLine($"Price - {grocery.Price} \n Expiration date - {grocery.ExpirationTime}" +
                        $"\n Amount left - {grocery.Amount}");
                }
                else { Console.WriteLine("No results!"); }
            }
        }

        public void FindDairy(string name)
        {
            foreach (var dairy in dairies)
            {
                if (dairy.Name == name)
                {
                    Console.WriteLine("Your product is available in this database! \n Here's information about it:");
                    Console.WriteLine($"Price - {dairy.Price} \n Expiration date - {dairy.ExpirationTime}" +
                        $"\n Amount left - {dairy.Amount}");
                }
                else { Console.WriteLine("No results!"); }
            }
        }

        public void DeleteGrocery(string name)
        {
            foreach (var grocery in groceries)
            {
                if (grocery.Name == name)
                {
                    Console.WriteLine("The product was found. Are you sure you want to remove it? " +
                        "\n Type [1] to confirm or another symbol to exit: ");
                    int confirm = Console.Read();
                    if (confirm == 1)
                    {
                        groceries.Remove(grocery);
                    }
                    else { return; }
                }
                else { Console.WriteLine("No results!"); }
            }
        }

        public void DeleteDairy(string name)
        {
            foreach (var dairy in dairies)
            {
                if (dairy.Name == name)
                {
                    Console.WriteLine("The product was found. Are you sure you want to remove it? " +
                        "\n Type [1] to confirm or another symbol to exit: ");
                    int confirm = Console.Read();
                    if (confirm == 1)
                    {
                        dairies.Remove(dairy);
                    }
                    else { return; }
                }
                else { Console.WriteLine("No results!"); }
            }
        }

        // sort amount of products using ICountable interface
        public void SortGreensByAmount()
        {
            groceries.Sort();
        }

        public void SortDairyByAmount()
        {
            dairies.Sort();
        }

        // delegate methods
        public void Shortage(int value)
        {
            if (value > TotalAmount)
            {
                Console.WriteLine("Cannot exceed the total amount of goods!");
            }
            else
            {
                Console.WriteLine($"You've just shortened the amount of stored products by {value}!" +
             $"\n Your current amount of products is - {TotalAmount - value} ");
            }
        }
        public void Supply(int value)
        {
            if (value <= 0)
            {
                Console.WriteLine("No supplies were added to the storage.");
            }
            else
            {
                Console.WriteLine($"You've just added to the amount of stored products by {value}!" +
             $"\n Your current amount of products is - {TotalAmount + value} ");
            }
        }

        // change method with delegate algorithm
        public void Change(int TotalAmount, ChangeAmount algo)
        {
            algo(TotalAmount);
        }



        internal void AddGrocery(string nameInfo, int priceInfo, double expirationInfo, int amountInfo, string category)
        {
            throw new NotImplementedException();
        }
        internal void AddDairy(string nameInfo, int priceInfo, double expirationInfo, int amountInfo, string category)
        {
            throw new NotImplementedException();
        }
    }
}
