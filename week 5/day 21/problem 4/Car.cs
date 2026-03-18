using System;

namespace Day21Programs
{
    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);
            return total + 500;
        }
    }
}