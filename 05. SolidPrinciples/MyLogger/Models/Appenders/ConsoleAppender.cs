using System;
using System.Globalization;

using MyLogger.Models.Common;
using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;

namespace MyLogger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public long MessageAppended { get; private set; }

        public void AppendError(IError error)
        {
            string formatMessage = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            Console.WriteLine(String.Format(formatMessage, dateTime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture), level.ToString().ToUpper(), message));

            this.MessageAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {typeof(ConsoleAppender)}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessageAppended}";
        }
    }
}
