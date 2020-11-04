using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Engine
    {
        private ICollection<IModelable> passengers;
        private ICollection<IModelable> rebels;

        public Engine()
        {
            this.passengers = new List<IModelable>();
            this.rebels = new List<IModelable>();
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var inputArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs.Length > 2)
                {
                    Human human = new Human(inputArgs[0], inputArgs[1], inputArgs[2]);
                    passengers.Add(human);
                }
                else
                {
                    Robot robot = new Robot(inputArgs[0], inputArgs[1]);
                    passengers.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            FindFakePassangers(passengers, fakeId);

            Console.WriteLine(string.Join(Environment.NewLine, rebels));
        }

        private void FindFakePassangers(IEnumerable<IModelable> passengers, string fakeId)
        {
            foreach (var passenger in passengers)
            {
                var lookUpValue = passenger.Id.Substring(passenger.Id.Length - fakeId.Length);
                if (lookUpValue == fakeId)
                {
                    rebels.Add(passenger);
                }
            }
        }
    }
}
