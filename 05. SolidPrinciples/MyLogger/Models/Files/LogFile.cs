using MyLogger.Models.Common;
using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MyLogger.Models.Files
{
    public class LogFile : IFile
    {
        private IIOManager IOManager;

        public LogFile(IIOManager iOManager)
        {
            this.IOManager = iOManager;
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.IOManager.GetCurrentDirectoryPath();

        public long Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formatMessage = String.Format(
                format,
                dateTime.ToString("G"),
                level.ToString().ToUpper(),
                message);

            return formatMessage;
        }

        public long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            return text.Where(x => char.IsLetter(x)).Sum(x => x);
        }
    }
}
