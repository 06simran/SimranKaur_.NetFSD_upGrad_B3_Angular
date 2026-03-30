using System;

class Program
{
    static void Main()
    {
        var config1 = ConfigurationManager.GetInstance();
        var config2 = ConfigurationManager.GetInstance();

        Console.WriteLine("App Name: " + config1.ApplicationName);
        Console.WriteLine("Version: " + config1.Version);

        Console.WriteLine("Same Instance? " + (config1 == config2));
    }
}