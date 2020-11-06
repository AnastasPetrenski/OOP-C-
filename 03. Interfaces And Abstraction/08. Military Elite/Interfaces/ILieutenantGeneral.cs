using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Interfaces
{
    public interface ILieutenantGeneral 
    {
        //decimal Salary { get; }

        ICollection<ISoldier> Privates { get; }
    }
}
