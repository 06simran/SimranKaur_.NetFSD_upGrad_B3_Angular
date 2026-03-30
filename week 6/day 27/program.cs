using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== SOLID Principles & Design Patterns =====");
            Console.WriteLine("1. SRP - Student Report");
            Console.WriteLine("2. OCP - Discount System");
            Console.WriteLine("3. LSP - Shape Area");
            Console.WriteLine("4. ISP - Printer सिस्टम");
            Console.WriteLine("5. Singleton - Configuration Manager");
            Console.WriteLine("6. Factory - Notification System");
            Console.WriteLine("7. Repository - Student Management");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RunSRP();
                    break;

                case 2:
                    RunOCP();
                    break;

                case 3:
                    RunLSP();
                    break;

                case 4:
                    RunISP();
                    break;

                case 5:
                    RunSingleton();
                    break;

                case 6:
                    RunFactory();
                    break;

                case 7:
                    RunRepository();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }