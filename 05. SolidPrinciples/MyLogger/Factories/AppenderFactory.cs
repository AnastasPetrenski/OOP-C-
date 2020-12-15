using MyLogger.Manager;
using MyLogger.Models.Appenders;
using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;
using MyLogger.Models.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLogger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender ProduceAppender(string appenderType, string layoutType, string levelStr)
        {
            ILayout layout = this.layoutFactory.ProduceLayout(layoutType);

            Level level;

            bool isParsed = Enum.TryParse<Level>(levelStr, true, out level);

            if (!isParsed)
            {
                throw new ArgumentException("Invalid level format!");
            }

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileApender")
            {
                IIOManager manager = new IOManager("Data", "logs.txt");

                IFile file = new LogFile(manager);

                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new ArgumentException("Invalid appender type");
            }

            return appender;
        }
    }
}
