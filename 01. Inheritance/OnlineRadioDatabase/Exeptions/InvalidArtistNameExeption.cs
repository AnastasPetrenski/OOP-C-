using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exeptions
{
    public class InvalidArtistNameExeption : InvalidSongExeption
    {
        public InvalidArtistNameExeption(string message = "Artist name should be between 3 and 20 symbols.")
            :base(message)
        {
        }
    }
}
