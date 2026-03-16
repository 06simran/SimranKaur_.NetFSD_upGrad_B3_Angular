using System;

namespace Day21Programs
{
    class Vehicle
    {
        private double rentalRatePerDay;

        public string? Brand { get; set; }

        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rental rate must be greater than zero.");
                }

                rentalRatePerDay = value;
            }
        }

        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                throw new ArgumentException("Rental days must be greater than zero.");
            }

            return RentalRatePerDay * days;
        }
    }
}