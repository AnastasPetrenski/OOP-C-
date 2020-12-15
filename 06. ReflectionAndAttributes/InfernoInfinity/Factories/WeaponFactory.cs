using InfernoInfinity.Contracts;
using System;

namespace InfernoInfinity.WeaponFactories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string levelOfRarity, string typeOfWeapon, string nameOfWeapon)
        {

            Type type = Type.GetType("InfernoInfinity.Models." + typeOfWeapon);
            IWeapon weapon = Activator.CreateInstance(type, new Object[] { levelOfRarity, nameOfWeapon}) as IWeapon;

            return weapon;
        }
    }
}
