using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exeptions
{
    public class InvalidSongSecondsException : InvalidSongExeption
    {
        public InvalidSongSecondsException(string message = "Song seconds should be between 0 and 59.")
            : base(message)
        {
        }
    }
}
