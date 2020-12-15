using MyLogger.Models.Common;
using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;
using MyLogger.Models.Errors;
using System;
using System.Globalization;

namespace MyLogger.Factories
{
    public class ErrorFactory 
    {
        public IError ProduceError(string levelStr, string dateStr, string messageStr)
        {
            Level level;

            bool isParst = Enum.TryParse<Level>(levelStr, true, out level);

            if (!isParst)
            {
                throw new ArgumentException("Invalid level format!");
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateStr, GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalild date format!");
            }

            IError error = new Error(dateTime, level, messageStr);

            return error;
        }
    }
}
