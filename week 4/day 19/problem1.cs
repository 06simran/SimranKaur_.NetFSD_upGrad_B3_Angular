using System;

namespace Day19
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    class Problem1
    {
        public static void Run()
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine()!);

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine()!);

            Calculator calc = new Calculator();

            int add = calc.Add(a, b);
            int sub = calc.Subtract(a, b);

            Console.WriteLine("Addition = " + add);
            Console.WriteLine("Subtraction = " + sub);
        }
    }
}