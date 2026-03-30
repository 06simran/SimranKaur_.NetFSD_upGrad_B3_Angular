using System;

class Program
{
    static void Main()
    {
        Shape rect = new Rectangle { Width = 5, Height = 4 };
        Shape circle = new Circle { Radius = 3 };

        Console.WriteLine("Rectangle Area: " + rect.CalculateArea());
        Console.WriteLine("Circle Area: " + circle.CalculateArea());
    }
}