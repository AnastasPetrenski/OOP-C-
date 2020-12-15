using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;
using System;

namespace MyLogger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, Level level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTime { get; private set; }

        public Level Level { get; private set; }

        public string Message { get; private set; }
    }
}
