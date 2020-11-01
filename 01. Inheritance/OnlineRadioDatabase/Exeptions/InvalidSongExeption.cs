using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exeptions
{
    public class InvalidSongExeption : Exception
    {
        public InvalidSongExeption(string message = "Invalid song.")
            :base(message)
        {
        }
    }
}
