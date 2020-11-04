using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Human : IModelable
    {
        public Human(string name, string age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
