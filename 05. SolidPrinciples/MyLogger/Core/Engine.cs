using System;
using System.Linq;

using MyLogger.Core.Contracts;
using MyLogger.Factories;
using MyLogger.Models.Contracts;

namespace MyLogger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger) : this()
        {
            this.errorFactory = new ErrorFactory();
            this.logger = logger;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string level = inputArgs[0];
                string dateTime = inputArgs[1];
                string message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTime, message, level);

                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
