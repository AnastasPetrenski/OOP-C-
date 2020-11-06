using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private ICollection<IModelable> members;
        private ICollection<IModelable> birthdays;

        public Engine()
        {
            this.members = new List<IModelable>();
            this.birthdays = new List<IModelable>();
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var inputArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs[0] == "Citizen")
                {
                    Human human = new Human(inputArgs[0], inputArgs[1], inputArgs[2], inputArgs[3], inputArgs[4]);
                    members.Add(human);
                }
                else if (inputArgs[0] == "Robot")
                {
                    Robot robot = new Robot(inputArgs[0], inputArgs[1], inputArgs[2]);
                    members.Add(robot);
                }
                else if (inputArgs[0] == "Pet")
                {
                    Pet pet = new Pet(inputArgs[0], inputArgs[1], inputArgs[2]);
                    members.Add(pet);
                }
            }

            string birthday = Console.ReadLine();

            FindFakePassangers(members, birthday);

            if (birthdays.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, birthdays));
            }
            
        }

        private void FindFakePassangers(IEnumerable<IModelable> members, string birthday)
        {
            foreach (var member in members.Where(p => p.Type != "Robot"))
            {
                var lookUpValue = member.Birthday.Substring(member.Birthday.Length - birthday.Length);
                if (lookUpValue == birthday)
                {
                    birthdays.Add(member);
                }
            }
        }
    }
}
