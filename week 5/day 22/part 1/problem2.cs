using System;

public class Calculator
{
    public void Divide(int numerator, int denominator)
    {
        try
        {
            int result = numerator / denominator;
            Console.WriteLine("Result = " + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero");
        }
        finally
        {
            Console.WriteLine("Operation completed safely");
        }
    }
}