using System;

namespace Day19
{
    class Product
    {
        private int productId;
        private string productName;
        private double unitPrice;
        private int qty;

        public Product(int id)
        {
            productId = id;
            productName = "";
        }

        public int ProductId
        {
            get { return productId; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int Quantity
        {
            get { return qty; }
            set { qty = value; }
        }

        public void ShowDetails()
        {
            double total = unitPrice * qty;

            Console.WriteLine("Product ID: " + productId);
            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Unit Price: " + unitPrice);
            Console.WriteLine("Quantity: " + qty);
            Console.WriteLine("Total Amount: " + total);
        }
    }

    class Assignment
    {
        public static void Run()
        {
            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Product p = new Product(id);

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product name cannot be empty");
                Console.ResetColor();
                return;
            }

            p.ProductName = name;

            Console.Write("Enter Unit Price: ");
            double price = double.Parse(Console.ReadLine()!);

            if (price < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unit price cannot be negative");
                Console.ResetColor();
                return;
            }

            p.UnitPrice = price;

            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine()!);

            if (quantity < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Quantity cannot be negative");
                Console.ResetColor();
                return;
            }

            p.Quantity = quantity;

            p.ShowDetails();
        }
    }
}