using OOP03InterfacesAndAbstraction.Enums;
using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string name, string family, decimal salary, string corpsEnum, ICollection<IRepair> repairs) 
            : base(id, name, family, salary, corpsEnum)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"{nameof(Corps)}: {CorpsEnum}")
                .AppendLine($"{nameof(Repairs)}:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
