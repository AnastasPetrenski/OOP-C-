using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Interfaces
{
    public interface ICommando 
    {
        ICollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
