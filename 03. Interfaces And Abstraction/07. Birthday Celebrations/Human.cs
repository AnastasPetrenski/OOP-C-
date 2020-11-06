using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Human : IModelable
    {
        public Human(string type, string name, string age, string id, string birthday)
        {
            this.Type = type;
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }

        public override string ToString()
        {
            return this.Birthday;
        }
    }
}
