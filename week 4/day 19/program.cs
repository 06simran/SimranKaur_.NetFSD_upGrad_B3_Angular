using System;

namespace Day19
{
    class Program
    {
        static void Main()
        {
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("\nSelect Program");
                Console.WriteLine("1. Simple Calculator");
                Console.WriteLine("2. Student Grade Calculator");
                Console.WriteLine("3. Product Assignment");
                Console.WriteLine("4. Exit");

                Console.Write("Enter Choice: ");
                choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        Problem1.Run();
                        break;

                    case 2:
                        Problem2.Run();
                        break;

                    case 3:
                        Assignment.Run();
                        break;

                    case 4:
                        Console.WriteLine("Exiting Program...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}