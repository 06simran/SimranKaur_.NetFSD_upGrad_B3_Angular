using System;

namespace Day21Programs
{
    class Product
    {
        private double price;

        public string ? Name { get; set; }

        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Price should be greater than zero .");
                }
                else
                {
                    price = value;
                }
            }
        }

        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }
}