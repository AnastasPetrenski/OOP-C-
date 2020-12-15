using System.Collections.Generic;
using System.Text;

using MyLogger.Models.Contracts;

namespace MyLogger.Models.Loggers
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.AppendError(error);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Logger info");
            foreach (IAppender appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
