using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns.Singleton_Pattern
{
    public sealed class Singleton
    {
        private static Singleton instance;
        private static object someLock = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                //Double check for multithreading, secured thread safe
                if (instance == null)
                {
                    lock(someLock)
                    {
                        if (instance == null)
                            Console.WriteLine("Create new instance");
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }

        public void LogToFile()
        {
            Console.WriteLine("Log to file!");
            //TODO LogToFile
        }
    }
}
