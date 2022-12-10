using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Course_Work_Supermarket
{
    // declared enum
    public enum DairyCategory { Cheese, MilkProduct, IceCream }

    // derivative class with serialization and interface usage
    [Serializable]
    public class Dairy : Product, IComparable<Dairy>
    {
        public DairyCategory Type { get; set; }

        public Dairy() { }
        public Dairy(string name, decimal price, double expiration, int amount, DairyCategory type) 
            : base(name, price, expiration, amount)
        {
            Name = name;
            Price = price;
            ExpirationTime = expiration;
            Amount = amount;
            Type = type;
        }
        public override void Inform()
        {
            Console.WriteLine("You've entered the diary department!");
        }

        public override string ToString()
        {
            return $"Name of the dairy product - {Name} \n" +
                $"Current price - {Price} \n Expiration date - {ExpirationTime} \n" +
                $"Amount of products - {Amount} \n Type of a product - {Type}";
        }

        // compare products by their amount
        public int CompareTo(Dairy other)
        {
            return Amount.CompareTo(other.Amount);
        }
    }
}
