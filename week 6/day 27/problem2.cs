using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter type (regular/premium/vip): ");
        string type = Console.ReadLine();

        IDiscountStrategy strategy = type.ToLower() switch
        {
            "regular" => new RegularCustomerDiscount(),
            "premium" => new PremiumCustomerDiscount(),
            "vip" => new VipCustomerDiscount(),
            _ => null
        };

        double amount = 1000;
        var calculator = new DiscountCalculator();

        if (strategy != null)
        {
            double finalPrice = calculator.GetFinalPrice(amount, strategy);
            Console.WriteLine("Final Price: " + finalPrice);
        }
        else
        {
            Console.WriteLine("Invalid type!");
        }
    }
}