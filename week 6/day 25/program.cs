using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Select Problem to Run:");
        Console.WriteLine("1. Async File Logger");
        Console.WriteLine("2. Discount Calculator");
        Console.WriteLine("3. Concurrent Reports");
        Console.WriteLine("4. Async Order Processing");
        Console.WriteLine("5. Order Tracing System");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                await RunAsyncLogger();
                break;
            case 2:
                RunDiscountCalculator();
                break;
            case 3:
                await RunReports();
                break;
            case 4:
                await RunOrderProcessing();
                break;
            case 5:
                RunTracingSystem();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    // Problem 1
    static async Task WriteLogAsync(string message)
    {
        await Task.Delay(1000);
        Console.WriteLine($"Log Written: {message}");
    }

    static async Task RunAsyncLogger()
    {
        Console.WriteLine("Starting Async Logging...");
        await Task.WhenAll(
            WriteLogAsync("Event 1"),
            WriteLogAsync("Event 2"),
            WriteLogAsync("Event 3")
        );
        Console.WriteLine("All logs completed");
    }

    // Problem 2
    static void RunDiscountCalculator()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Discount %: ");
        double discount = Convert.ToDouble(Console.ReadLine());

        double finalPrice = price - (price * discount / 100);

        Console.WriteLine($"Final Price of {name}: {finalPrice}");
    }

    // Problem 3
    static async Task GenerateSalesReport()
    {
        Console.WriteLine("Sales Report Started");
        await Task.Delay(2000);
        Console.WriteLine("Sales Report Completed");
    }

    static async Task GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report Started");
        await Task.Delay(3000);
        Console.WriteLine("Inventory Report Completed");
    }

    static async Task GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report Started");
        await Task.Delay(1500);
        Console.WriteLine("Customer Report Completed");
    }

    static async Task RunReports()
    {
        Console.WriteLine("Running Reports Concurrently...");

        Task t1 = Task.Run(GenerateSalesReport);
        Task t2 = Task.Run(GenerateInventoryReport);
        Task t3 = Task.Run(GenerateCustomerReport);

        await Task.WhenAll(t1, t2, t3);

        Console.WriteLine("All Reports Completed");
    }

    // Problem 4
    static async Task VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying Payment...");
        await Task.Delay(1000);
    }

    static async Task CheckInventoryAsync()
    {
        Console.WriteLine("Checking Inventory...");
        await Task.Delay(1000);
    }

    static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Confirming Order...");
        await Task.Delay(1000);
    }

    static async Task RunOrderProcessing()
    {
        Console.WriteLine("Order Processing Started");

        await VerifyPaymentAsync();
        await CheckInventoryAsync();
        await ConfirmOrderAsync();

        Console.WriteLine("Order Completed Successfully");
    }

    // Problem 5
    static void RunTracingSystem()
    {
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
        Trace.AutoFlush = true;

        Trace.WriteLine("Order Processing Started");

        Trace.TraceInformation("Validating Order");
        Thread.Sleep(500);

        Trace.TraceInformation("Processing Payment");
        Thread.Sleep(500);

        Trace.TraceInformation("Updating Inventory");
        Thread.Sleep(500);

        Trace.TraceInformation("Generating Invoice");
        Thread.Sleep(500);

        Trace.WriteLine("Order Processing Completed");

        Console.WriteLine("Tracing Completed. Check log.txt file.");
    }
}
