using System;

namespace Day21Programs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== OOP Practice Menu =====");
                Console.WriteLine("1. Bank Account System");
                Console.WriteLine("2. Employee Salary Calculator");
                Console.WriteLine("3. Online Shopping Cart");
                Console.WriteLine("4. Vehical Rental System");
                Console.WriteLine("5. Exit");


                Console.Write("Select Program: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BankAccountProgram.Run();
                        break;

                    case 2:
                        EmployeeSalaryProgram.Run();
                        break;

                    case 3:
                        ShoppingCartProgram.Run();
                        break;

                    case 4:
                        VehicleRentalProgram.Run();
                        break;

                    case 5:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}