using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerators;
using System;
using System.Globalization;

namespace Logger.Models.Appenders
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

        public long MessegesAppended { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formatMessage = String.Format(
                format,
                dateTime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture),
                level.ToString().ToUpper(),
                message);

            Console.WriteLine(formatMessage);
            this.MessegesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessegesAppended}";
        }
    }
}
