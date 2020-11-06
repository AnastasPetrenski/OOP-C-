using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    class Spy : Soldier, ISpy
    {
        public Spy(int id, string name, string family, int codeNumber) 
            : base(id, name, family)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Code Number: {CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
