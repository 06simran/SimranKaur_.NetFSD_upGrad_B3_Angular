using System;

namespace Day18
{
    class problem1
    {
        public static void Run()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine()!);

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks");
                return;
            }

            string grade;

            if (marks >= 80)
                grade = "A";
            else if (marks >= 60)
                grade = "B";
            else if (marks >= 50)
                grade = "C";
            else if (marks >= 40)
                grade = "D";
            else
                grade = "Fail";

            Console.WriteLine($"Student: {name}");
            Console.WriteLine($"Grade: {grade}");
        }
    }
}