using BarracksWarANewFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Models
{
    public class Repository : IRepository
    {
        private readonly IDictionary<string, int> units;

        public Repository()
        {
            this.units = new SortedDictionary<string, int>();
        }

        public void Add(IUnit unit)
        {
            string name = unit.GetType().Name;
            if (!this.units.ContainsKey(name))
            {
                this.units.Add(name, 0);
            }

            this.units[name]++;
            //Console.WriteLine($"{unit.GetType().Name} added!");
        }

        public string Retire(string name)
        {
            if (!this.units.ContainsKey(name))
            {
                return "No such units in repository.";
            }
            else
            {
                this.units[name]--;
                return $"{name} retired!";
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var item in this.units)
            {
                sb.AppendLine($"{item.Key} -> {item.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
