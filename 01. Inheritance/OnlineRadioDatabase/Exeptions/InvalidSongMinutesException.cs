using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exeptions
{
    public class InvalidSongMinutesException : InvalidSongExeption
    {
        public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.")
            : base(message)
        {
        }
    }
}
