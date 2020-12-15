using System;

using BarracksWarANewFactory.Contracts;

namespace BarracksWarANewFactory
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string command)
        {
            Type type = Type.GetType("BarracksWarANewFactory.Models." + command);
            IUnit unit = Activator.CreateInstance(type) as IUnit;

            return unit;
        }
    }
}
