using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IModelable
    {
        public Robot(string type, string name, string birthday)
        {
            this.Type = type;
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }

        public override string ToString()
        {
            return this.Birthday;
        }
    }
}
