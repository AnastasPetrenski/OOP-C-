using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exeptions
{
    public class InvalidSongNameException : InvalidSongExeption
    {
        public InvalidSongNameException(string message = "Song name should be between 3 and 30 symbols.")
            : base (message)
        {
        }
    }
}
