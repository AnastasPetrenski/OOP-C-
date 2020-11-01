using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exeptions
{
    public class InvalidSongLengthException : InvalidSongExeption
    {
        public InvalidSongLengthException(string message = "Invalid song length.")
            : base(message)
        {
        }
    }
}
