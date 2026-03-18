using System;

namespace Day21Programs
{
    class VehicleRentalProgram
    {
        public static void Run()
        {
            try
            {
                Console.WriteLine("Select Vehicle Type");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Bike");

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Brand: ");
                string? brand = Console.ReadLine();

                Console.Write("Enter Rental Rate Per Day: ");
                double rate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Number of Days: ");
                int days = Convert.ToInt32(Console.ReadLine());

                Vehicle vehicle;

                if (choice == 1)
                    vehicle = new Car();
                else
                    vehicle = new Bike();

                vehicle.Brand = brand;
                vehicle.RentalRatePerDay = rate;

                double total = vehicle.CalculateRental(days);

                Console.WriteLine("Total Rental Cost = " + total);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}