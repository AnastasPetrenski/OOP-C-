using MyLogger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyLogger.Manager
{
    public class IOManager : IIOManager
    {
        private const string PATH_DELIMITER = "\\";
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentDirectoryPath();
        }

        public IOManager(string folderName, string fileName) : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => Path.Combine(this.currentPath, this.folderName);

        public string CurrentFilePath => this.CurrentDirectoryPath + PATH_DELIMITER + this.fileName;

        public void EnsureDirectoryAndFileExist()
        {

            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectoryPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
