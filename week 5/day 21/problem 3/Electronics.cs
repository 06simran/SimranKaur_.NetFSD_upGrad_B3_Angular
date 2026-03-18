namespace Day21Programs
{
    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }
}