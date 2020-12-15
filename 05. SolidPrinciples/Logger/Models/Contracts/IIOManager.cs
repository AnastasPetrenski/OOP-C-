﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface  IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentDirectory();

        void EnsureDirectoryAndFileExist();
    }
}
