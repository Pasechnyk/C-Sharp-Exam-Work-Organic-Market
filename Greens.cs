using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Course_Work_Supermarket
{
    // declared enum
    public enum GreenCategory { Vegetable, Fruit, Herbs }

    // derivative class with serialization and interface usage
    [Serializable]
    public class Greens : Product, IComparable<Greens>
    {
        public GreenCategory Type { get; set; }

        public Greens() { }
        public Greens(string name, decimal price, double expiration, int amount, GreenCategory type) 
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
            Console.WriteLine("You've entered grocery department!");
        }
        public override string ToString()
        {
            return $"Name of the grocery product - {Name} \n" +
                $"Current price - {Price} \n Expiration date - {ExpirationTime} \n" +
                $"Amount of products - {Amount} \n Type of a product - {Type}";
        }

        // compare products by their amount
        public int CompareTo(Greens other)
        {
            return Amount.CompareTo(other.Amount);
        }
    }
}
