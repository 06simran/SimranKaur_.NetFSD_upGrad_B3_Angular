using System;

namespace Day21Programs
{
    class Employee
    {
        private double baseSalary;

        public string ? Name { get; set; }

        public double BaseSalary
        {
            get { return baseSalary; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Salary should be greater than zero.");
                }
                else
                {
                    baseSalary = value;
                }
            }
        }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }
}