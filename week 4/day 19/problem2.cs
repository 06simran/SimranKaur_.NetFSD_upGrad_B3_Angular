using System;

namespace Day19
{
    class Student
    {
        public double CalculateAverage(int m1, int m2, int m3)
        {
            return (m1 + m2 + m3) / 3.0;
        }
    }

    class Problem2
    {
        public static void Run()
        {
            Console.Write("Enter marks 1: ");
            int m1 = int.Parse(Console.ReadLine()!);

            Console.Write("Enter marks 2: ");
            int m2 = int.Parse(Console.ReadLine()!);

            Console.Write("Enter marks 3: ");
            int m3 = int.Parse(Console.ReadLine()!);

            // Check negative marks
            if (m1 < 0 || m2 < 0 || m3 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Marks cannot be negative");
                Console.ResetColor();
                return;
            }

            Student s = new Student();
            double avg = s.CalculateAverage(m1, m2, m3);

            char grade;

            if (avg >= 80)
                grade = 'A';
            else if (avg >= 60)
                grade = 'B';
            else if (avg >= 50)
                grade = 'C';
            else
                grade = 'F';

            Console.WriteLine("Average = " + avg);
            Console.WriteLine("Grade = " + grade);
        }
    }
}