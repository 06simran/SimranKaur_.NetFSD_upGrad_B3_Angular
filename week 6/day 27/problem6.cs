using System;

class Program
{
    static void Main()
    {
        var factory = new NotificationFactory();

        Console.WriteLine("Enter type (email/sms/push): ");
        string type = Console.ReadLine();

        var notification = factory.CreateNotification(type);

        if (notification != null)
            notification.Send("Welcome to our service!");
        else
            Console.WriteLine("Invalid type!");
    }
}