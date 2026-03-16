using System;

namespace Day21Programs
{
    class ShoppingCartProgram
    {
        public static void Run()
        {
            Console.WriteLine("Select Product Type");
            Console.WriteLine("1. Electronics");
            Console.WriteLine("2. Clothing");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product product;

            if (choice == 1)
                product = new Electronics()!;
            else
                product = new Clothing();

            product.Name = name;
            product.Price = price;

            double finalPrice = product.CalculateDiscount();

            Console.WriteLine("Final Price after discount = " + finalPrice);
        }
    }
}