using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._09._Lazy_Initialization_Pattern
{
    public class EngineBank
    {
        public void Run()
        {
            Lazy<BankAccount> bankAccount = new Lazy<BankAccount>(() => new BankAccount());
            Console.WriteLine("Main");

            Console.WriteLine(bankAccount.IsValueCreated);
            bankAccount.Value.Balance = 100;
            Console.WriteLine(bankAccount.Value.Balance);
        }
    }
}
