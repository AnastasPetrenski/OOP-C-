using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._09._Lazy_Initialization_Pattern
{
    public class BankAccount
    {
        public BankAccount()
        {
            Console.WriteLine("Initialized");
        }

        public int Balance { get; set; }
    }
}
