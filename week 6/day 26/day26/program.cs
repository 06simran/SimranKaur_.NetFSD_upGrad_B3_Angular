using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string conn = "Server=127.0.0.1,1433;Database=ProductDB;User Id=Username;Password=yourpassword;Encrypt=False;TrustServerCertificate=True;";        ProductData data = new ProductData(conn);

        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine("6. View Product By ID");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Product p = new Product();

                Console.Write("Name: ");
                p.ProductName = Console.ReadLine()!;

                Console.Write("Category: ");
                p.Category = Console.ReadLine()!;

                Console.Write("Price: ");
                p.Price = Convert.ToDecimal(Console.ReadLine());

                data.InsertProduct(p);
            }
            else if (choice == 2)
            {
                data.GetAllProducts();
            }
            else if (choice == 3)
            {
                Product p = new Product();

                Console.Write("ID: ");
                p.ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Name: ");
                p.ProductName = Console.ReadLine()!;

                Console.Write("Category: ");
                p.Category = Console.ReadLine()!;

                Console.Write("Price: ");
                p.Price = Convert.ToDecimal(Console.ReadLine());

                data.UpdateProduct(p);
            }
            else if (choice == 4)
            {
                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                data.DeleteProduct(id);
            }
            else if (choice == 6) // NEW OPTION
            {
                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                data.GetProductById(id);
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}