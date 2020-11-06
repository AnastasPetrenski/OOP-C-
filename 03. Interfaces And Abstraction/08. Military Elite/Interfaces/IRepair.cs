using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Interfaces
{
    public interface IRepair
    {
        public string PartName { get; }

        public int HoursWork { get; }
    }
}
