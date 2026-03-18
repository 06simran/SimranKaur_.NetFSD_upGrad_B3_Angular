using System;

namespace Day21Programs
{
    class EmployeeSalaryProgram
    {
        public static void Run()
        {
            Console.Write("Enter Base Salary: ");
            double baseSalary = Convert.ToDouble(Console.ReadLine());

            Employee manager = new Manager();
            manager.BaseSalary = baseSalary;

            Employee developer = new Developer();
            developer.BaseSalary = baseSalary;

            Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
            Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
        }
    }
}