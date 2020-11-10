using System;
using System.Threading;
using System.Threading.Tasks;

namespace LockStatementInMultiThreadingExample
{
    class Program
    {
        public class Account
        {
            private readonly object balanceLock = new object();
            private decimal balance;

            public Account(decimal initialBalance) => balance = initialBalance;

            public decimal Debit(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
                }

                decimal appliedAmount = 0;
                lock (balanceLock)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                        appliedAmount = amount;
                        Console.WriteLine($"In Debit {balance}");
                    }
                }
                return appliedAmount;
            }

            public void Credit(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "The credit amount cannot be negative.");
                }

                lock (balanceLock)
                {
                    balance += amount;
                    Console.WriteLine($"In Credit {balance}");
                }
            }

            public decimal GetBalance()
            {
                lock (balanceLock)
                {
                    return balance;
                }
            }
        }

        class AccountTest
        {
            static async Task Main()
            {
                var account = new Account(1000);
                var tasks = new Task[5];
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(() => Update(account));
                    Console.WriteLine($"Generate Task{i}");
                }
                Console.WriteLine($"WhenAll start");
                await Task.WhenAll(tasks);
                Console.WriteLine($"WhenAll finish");
                Console.WriteLine($"Account's balance is {account.GetBalance()}");
                // Output:
                // Account's balance is 1050

                // Creating and initializing threads 
                Thread thr1 = new Thread(method1);
                Thread thr2 = new Thread(method2);
                thr1.Start();
                thr2.Start();

                //Output
                /*
                    Method1 is : 0
                    Method1 is : 1
                    Method1 is : 2
                    Method1 is : 3
                    Method2 is : 0
                    Method2 is : 1
                    Method2 is : 2
                    Method2 is : 3
                    Method2 is : 4
                    Method2 is : 5
                    Method2 is : 6
                    Method2 is : 7
                    Method2 is : 8
                    Method2 is : 9
                    Method2 is : 10
                    Method1 is : 4
                    Method1 is : 5
                    Method1 is : 6
                    Method1 is : 7
                    Method1 is : 8
                    Method1 is : 9
                    Method1 is : 10
                 */
            }


            //First Example Code Methods
            static void Update(Account account)
            {
                decimal[] amounts = { 0, 2, -3, 6, -2, -1, 8, -5, 11, -6 };
                foreach (var amount in amounts)
                {
                    if (amount >= 0)
                    {
                        account.Credit(amount);
                        Console.WriteLine($"Update balance with positive {amount}");
                    }
                    else
                    {
                        account.Debit(Math.Abs(amount));
                        Console.WriteLine($"Update balance with negative {amount}");
                    }
                }
            }


            //Second Example Code Methods
            // static method one 
            public static void method1()
            {

                // It prints numbers from 0 to 10 
                for (int I = 0; I <= 10; I++)
                {
                    Console.WriteLine("Method1 is : {0}", I);

                    // When the value of I is equal to 5 then 
                    // this method sleeps for 6 seconds 
                    if (I == 5)
                    {
                        Thread.Sleep(6000);
                    }
                }
            }

            // static method two 
            public static void method2()
            {
                // It prints numbers from 0 to 10 
                for (int J = 0; J <= 10; J++)
                {
                    Console.WriteLine("Method2 is : {0}", J);
                }
            }

        }
    }
}
