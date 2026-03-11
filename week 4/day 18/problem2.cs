using System;

namespace Day18
{
    class problem2
    {
        public static void Run()
        {
            Console.Write("Enter First Number: ");
            double num1 = double.Parse(Console.ReadLine()!);

            Console.Write("Enter Second Number: ");
            double num2 = double.Parse(Console.ReadLine()!);

            Console.Write("Enter Operator (+ - * /): ");
            char op = Convert.ToChar(Console.ReadLine()!);

            double result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Division by zero not allowed");
                        return;
                    }
                    result = num1 / num2;
                    break;

                default:
                    Console.WriteLine("Invalid Operator");
                    return;
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}