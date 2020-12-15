using InfernoInfinity.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace InfernoInfinity.Models
{
    public class Repository : IRepository
    {
        private ICollection<IWeapon> weapons;

        public Repository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void Add(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public void DamageGenerator(IWeapon weapon)
        {

        }

        public IWeapon GetWeapon(string weaponName)
        {
            return this.weapons.FirstOrDefault(w => w.Name == weaponName);
        }
    }
}
