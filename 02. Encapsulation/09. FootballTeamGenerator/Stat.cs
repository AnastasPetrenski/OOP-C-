using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stat
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const double STATS_CNT = 5;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(string[] stats)
        {
            this.Endurance = int.Parse(stats[0]);
            this.Sprint = int.Parse(stats[1]);
            this.Dribble = int.Parse(stats[2]);
            this.Passing = int.Parse(stats[3]);
            this.Shooting = int.Parse(stats[4]);
        }

        public int Endurance 
        {
            get => this.endurance; 
            private set
            {
                ValidateStat(nameof(Endurance), value);

                this.endurance = value;
            }
        }

        private int Sprint
        {
            get => this.sprint;
            set
            {
                ValidateStat(nameof(Sprint), value);

                this.sprint = value;
            }
        }

        private int Dribble
        {
            get => this.dribble;
            set
            {
                ValidateStat(nameof(Dribble), value);

                this.dribble = value;
            }
        }

        private int Passing
        {
            get => this.passing;
            set
            {
                ValidateStat(nameof(Passing), value);

                this.passing = value;
            }
        }

        private int Shooting
        {
            get => this.shooting;
            set
            {
                ValidateStat(nameof(Shooting), value);

                this.shooting = value;
            }
        }

        public double Average()
        {
            double result = (Endurance + Sprint + Dribble + Passing + Shooting) / STATS_CNT;
            return result;
        }

        private void ValidateStat(string name, int value)
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException(message:String.Format(GlobalConstants.InvalidStatsExcMsg, name, MIN_STAT, MAX_STAT));
            }
        }
    }
}
