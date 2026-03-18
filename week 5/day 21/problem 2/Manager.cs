namespace Day21Programs
{
    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }
}