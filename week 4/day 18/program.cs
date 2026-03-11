using System;
using Day18;

class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\nChoose Problem:");
            Console.WriteLine("1. Student Grade Evaluator");
            Console.WriteLine("2. Simple Calculator");
            Console.WriteLine("3. Employee Bonus Calculator");
            Console.WriteLine("4. Number Analysis");
            Console.WriteLine("5. Exit");

            choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    problem1.Run();
                    break;

                case 2:
                    problem2.Run();
                    break;

                case 3:
                    problem3.Run();
                    break;

                case 4:
                    problem4.Run();
                    break;

                case 5:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 5);
    }
}