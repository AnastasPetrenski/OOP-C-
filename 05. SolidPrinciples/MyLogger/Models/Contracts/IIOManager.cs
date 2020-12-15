using System;
using System.Collections.Generic;
using System.Text;

namespace MyLogger.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentDirectoryPath();

        void EnsureDirectoryAndFileExist();

    }
}
