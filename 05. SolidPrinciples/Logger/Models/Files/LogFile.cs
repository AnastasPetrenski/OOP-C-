using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerators;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string pathName)
        {
            this.IOManager = new IOManager(folderName, pathName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        /// <summary>
        /// Returns formatted message in provided layout with provided error's data
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatMessage = String.Format( 
                 format, 
                 dateTime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture), 
                 message, level.ToString()) + Environment.NewLine;

            return formatMessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            return text.Where(ch => char.IsLetter(ch)).Sum(ch => ch);
        }
    }
}
