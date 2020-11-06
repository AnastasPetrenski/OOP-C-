using OOP03InterfacesAndAbstraction.Enums;
using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string name, string family, decimal salary, string corpsEnum) 
            : base(id, name, family, salary, corpsEnum)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; private set; }

        public void AddMission(IMission mission)
        {
            this.Missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"{nameof(Corps)}: {CorpsEnum}")
                .AppendLine($"{nameof(Missions)}:");
            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
