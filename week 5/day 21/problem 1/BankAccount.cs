using System;

namespace Day21Programs
{
    class BankAccount
    {
        private int accountNumber;
        private double balance;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount. Must be greater than zero.");
                return;
            }

            balance += amount;
            Console.WriteLine("Deposited: " + amount);
            Console.WriteLine("Current Balance: " + balance);
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Withdrawal failed. Insufficient balance.");
                return;
            }

            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
            Console.WriteLine("Current Balance: " + balance);
        }
    }
}