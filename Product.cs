using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Course_Work_Supermarket
{
    // creation of abstract class 
    public abstract class Product
    {
        // auto-properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double ExpirationTime { get; set; }
        public int Amount { get; set; }

        // constructors
        public Product() { }
        public Product(string name, decimal price, double expiration, int amount)
        {
            Name = name;
            Price = price;
            ExpirationTime = expiration;
            Amount = amount;
        }

        // abstract method
        public abstract void Inform();

    }
}
