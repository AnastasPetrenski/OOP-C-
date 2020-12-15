using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath)
                {
                    while (astronaut.CanBreath && planet.Items.Count > 0)
                    {
                        var item = planet.Items.FirstOrDefault();
                        if (item != null)
                        {
                            astronaut.Breath();
                            astronaut.Bag.Items.Add(item);
                            planet.Items.Remove(item);
                        }
                    }

                    //if (!astronaut.CanBreath)
                    //{
                    //    astronaut.Bag.Items.Clear();
                    //}
                }
                
            }
            
        }
    }
}
