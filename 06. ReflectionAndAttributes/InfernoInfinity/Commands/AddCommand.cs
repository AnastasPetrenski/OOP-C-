using InfernoInfinity.Contracts;
using InfernoInfinity.Factories;
using System;

namespace InfernoInfinity.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository) : base(data, repository)
        {
            this.GemFactory = new GemFactory();
        }

        public IGemFactory GemFactory { get; }

        public override void Execute()
        {
            //•	Add;{weapon name};{socket index};{levelOfClarity gemtype}
            try
            {
                string weaponName = this.Data[0];
                var currentWeapon = this.Repository.GetWeapon(weaponName);
                int index = int.Parse(this.Data[1]);
                
                if (currentWeapon.CheckSocket(index))
                {
                    var gemArgs = this.Data[2].Split();
                    string levelOfClarity = gemArgs[0];
                    string gemType = gemArgs[1];
                    var gem = this.GemFactory.CreateGem(gemType, levelOfClarity);
                    currentWeapon.InsertGemAtSocket(index, gem);
                }
            }
            catch (Exception)
            {
            }
            
        }
    }
}
