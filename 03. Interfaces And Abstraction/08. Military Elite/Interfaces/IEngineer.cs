using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Interfaces
{
    public interface IEngineer 
    {
        ICollection<IRepair> Repairs { get; }
    }
}
