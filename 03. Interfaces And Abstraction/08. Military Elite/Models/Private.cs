using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string name, string family, decimal salary) 
            : base(id, name, family)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .Append(base.ToString())
                .AppendLine($" {nameof(Salary)}: {Salary:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
