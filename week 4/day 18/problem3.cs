using System;

namespace Day18
{
    class problem3
    {
        public static void Run()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine()!);

            if (salary < 0)
            {
                Console.WriteLine("Salary cannot be negative.");
                return;
            }

            Console.Write("Enter Experience: ");
            int exp = int.Parse(Console.ReadLine()!);

            if (exp < 0)
            {
                Console.WriteLine("Experience cannot be negative.");
                return;
            }

            double bonus;

            if (exp < 2)
                bonus = salary * 0.05;
            else if (exp <= 5)
                bonus = salary * 0.10;
            else
                bonus = salary * 0.15;

            double finalSalary = salary + bonus;

            Console.WriteLine($"Employee: {name}");
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine($"Final Salary: {finalSalary}");
        }
    }
}