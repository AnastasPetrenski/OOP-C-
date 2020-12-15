using InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Commands
{
    public class RemoveCommand : Command
    {
        public RemoveCommand(string[] data, IRepository repository) : base(data, repository)
        {
        }

        public override void Execute()
        {
            //•	Remove;{weapon name};{socket index}
            string weaponName = this.Data[0];
            var currentWeapon = this.Repository.GetWeapon(weaponName);
            int index = int.Parse(this.Data[1]);
            if (currentWeapon.CheckSocket(index))
            {
                try
                {
                    currentWeapon.Gems.RemoveAt(index);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
