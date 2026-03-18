using System;

namespace Day21Programs
{
    class BankAccountProgram
    {
        public static void Run()
        {
            BankAccount account = new BankAccount();

            Console.Write("Enter Account Number: ");
            account.AccountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Deposit Amount: ");
            double deposit = Convert.ToDouble(Console.ReadLine());
            account.Deposit(deposit);

            Console.Write("Enter Withdraw Amount: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());
            account.Withdraw(withdraw);

            Console.WriteLine("Final Balance = " + account.Balance);
        }
    }
}