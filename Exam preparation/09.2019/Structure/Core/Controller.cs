using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private IMission mission;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = type switch
            {
                "Biologist" => new Biologist(astronautName),
                "Geodesist" => new Geodesist(astronautName),
                "Meteorologist" => new Meteorologist(astronautName),
                _=> throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType)
            };

            this.astronautRepository.Add(astronaut);

            return String.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronaut.Name);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return String.Format(OutputMessages.PlanetAdded, planet.Name);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planetRepository.FindByName(planetName);
            var team = astronautRepository.Models.Where(a => a.Oxygen >= 60).ToList();
            if (team.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautCount));
            }

            this.mission.Explore(planet, team);
            this.exploredPlanetsCount++;
            return String.Format(OutputMessages.PlanetExplored, planetName, team.Where(a => a.CanBreath == false).Count());
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            {
                sb.Append(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var retiredAstronaut = astronautRepository.FindByName(astronautName);
            if (retiredAstronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronautRepository.Remove(retiredAstronaut);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
