using System;

namespace Day21Programs
{
    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);
            return total - (total * 0.05);
        }
    }
}