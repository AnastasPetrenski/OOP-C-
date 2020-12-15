using InfernoInfinity.Contracts;
using InfernoInfinity.WeaponFactories;
using System.Linq;

namespace InfernoInfinity.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(string[] data, IRepository repository) : base(data, repository)
        {
            this.WeaponFactory = new WeaponFactory();
        }

        public IWeaponFactory WeaponFactory { get; }

        public override void Execute()
        {
            //•	Create;{levelRarity weaponType};{weaponName}
            var weaponArgs = this.Data[0].Split().ToArray();
            var weaponLevel = weaponArgs[0];
            var weaponType = weaponArgs[1];
            var weaponName = this.Data[1];
            var weapon = this.WeaponFactory.CreateWeapon(weaponLevel, weaponType, weaponName);
            this.Repository.Add(weapon);
        }
    }
}
