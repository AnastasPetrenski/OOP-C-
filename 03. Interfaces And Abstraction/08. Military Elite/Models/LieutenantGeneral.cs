using OOP03InterfacesAndAbstraction.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string name, string family, decimal salary, List<ISoldier> privates) 
            : base(id, name, family, salary)
        {
            this.Privates = privates;
        }

        public ICollection<ISoldier> Privates { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"{nameof(Privates)}:");
            foreach (var item in this.Privates)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
