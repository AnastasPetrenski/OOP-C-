using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string command);
    }
}
