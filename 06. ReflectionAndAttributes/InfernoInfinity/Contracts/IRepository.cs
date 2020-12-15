using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Contracts
{
    public interface IRepository
    {
        void Add(IWeapon weapon);
        IWeapon GetWeapon(string weaponName); 
    }
}
