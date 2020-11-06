using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(int id, string name, string family)
        {
            this.Id = id;
            this.Name = name;
            this.Family = family;
        }

        public int Id { get; }

        public string Name { get; }

        public string Family { get; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name} {Family} {nameof(Id)}: {Id}";
        }

    }
}
