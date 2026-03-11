using System;

namespace Day18
{
    class problem4
    {
        public static void Run()
        {
            Console.Write("Enter Number: ");
            int N = int.Parse(Console.ReadLine()!);

            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            for (int i = 1; i <= N; i++)
            {
                sum += i;

                if (i % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }

            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count: {oddCount}");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}