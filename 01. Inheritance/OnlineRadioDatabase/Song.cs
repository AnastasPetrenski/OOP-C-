using OnlineRadioDatabase.Exeptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;

        public Song(string[] arguments)
        {
            ValidateArguments(arguments);
            this.ArtistName = arguments[0];
            this.SongName = arguments[1];
            int[] lengthArgs = ValidateLengthArguments(arguments[2]);
            this.Minutes = lengthArgs[0];
            this.Seconds = lengthArgs[1];
        }

        private int[] ValidateLengthArguments(string args)
        {
            var arguments = args.Split(':');
            if (arguments.Length != 2 || arguments.Any(x => !x.All(y => char.IsDigit(y))))
            {
                throw new InvalidSongLengthException();
            }

            return arguments.Select(int.Parse).ToArray();
        }

        private void ValidateArguments(string[] arguments)
        {
            if (arguments.Length != 3)
            {
                throw new InvalidSongExeption();
            }
        }

        public string ArtistName 
        {
            get { return this.artistName; } 
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.artistName = value;
            }
        }
        public string SongName 
        {
            get { return this.songName; }
            set 
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameExeption();
                }

                this.songName = value;
            }
        }
        public int Minutes 
        {
            get { return this.minutes; } 
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }
        public int Seconds 
        {
            get { return this.seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
        public int GetLengthInSeconds()
        {
            return this.minutes * 60 + this.seconds;
        }
    }
}
