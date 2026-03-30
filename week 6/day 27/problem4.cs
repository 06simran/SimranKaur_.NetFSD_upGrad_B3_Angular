using System;

class Program
{
    static void Main()
    {
        IPrinter basic = new BasicPrinter();
        basic.Print();

        Console.WriteLine("----");

        AdvancedPrinter advanced = new AdvancedPrinter();
        advanced.Print();
        advanced.Scan();
        advanced.Fax();
    }
}