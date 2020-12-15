using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IRider> riders;
        private IRepository<IRace> races;
        private IRepository<IMotorcycle> motorcycles;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.races = new RaceRepository();
            this.motorcycles = new MotorcycleRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motorcycle = motorcycles.GetByName(motorcycleModel);
            if (motorcycle == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return String.Format(OutputMessages.MotorcycleAdded, rider.Name, motorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = type switch
            {
                "Power" => new PowerMotorcycle(model, horsePower),
                "Speed" => new SpeedMotorcycle(model, horsePower),
                _ => throw new NotImplementedException(),
            };

            var existed = motorcycles.GetByName(model);

            if (existed != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }

            motorcycles.Add(motorcycle);

            return String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            var existed = races.GetByName(name);
            if (existed != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RaceExists, name));
            }

            races.Add(race);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);

            var existed = riders.GetByName(riderName);

            if (existed != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }

            riders.Add(rider);

            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var winners = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();
            
                    sb.AppendLine(String.Format(OutputMessages.RiderFirstPosition, winners[0].Name, race.Name));
                    sb.AppendLine(String.Format(OutputMessages.RiderSecondPosition, winners[1].Name, race.Name));
                    sb.AppendLine(String.Format(OutputMessages.RiderThirdPosition, winners[2].Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}
