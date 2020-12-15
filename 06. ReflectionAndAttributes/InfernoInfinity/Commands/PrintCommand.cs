using InfernoInfinity.Contracts;
using InfernoInfinity.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand(string[] data, IRepository repository) : base(data, repository)
        {
        }

        public override void Execute()
        {
            //•	Print;{weapon name}
            string weaponName = this.Data[0];
            var currentWeapon = this.Repository.GetWeapon(weaponName);
            var msg = CalculatingPoints(currentWeapon);
            Console.WriteLine(msg);
        }

        public string CalculatingPoints(IWeapon weapon)
        {
            int strength = 0;
            int agility = 0;
            int vitality = 0;

            foreach (var item in weapon.Gems)
            {
                int levelOfClarity = ChechLevelOfClarity(item.LevelOfClarity);
                strength += (item.Strength + levelOfClarity);
                agility += (item.Agiity + levelOfClarity);
                vitality += (item.Vitality + levelOfClarity);
            }

            var info = weapon.GetType().GetProperty("Damage");
            var attributes = info.GetCustomAttributes(true);
            var minDmg = 0;
            var maxDmg = 0;
            
            foreach (DamageAttribute item in attributes)
            {   
                minDmg = item.Min;
                maxDmg = item.Max;
            }

            int levelOfRarity = CheckLevelOfRarity(weapon.LevelOfRarity);
            if (levelOfRarity > 0)
            {
                minDmg *= levelOfRarity;
                maxDmg *= levelOfRarity;
            }

            minDmg += ((strength * 2) + agility);
            maxDmg += ((strength * 3) + (agility * 4));

            //"{weapon's name}: {min damage}-{max damage} Damage, +{points} Strength, +{points} Agility, +{points} Vitality"
            return $"{weapon.Name}: {minDmg}-{maxDmg} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }

        private int CheckLevelOfRarity(string levelOfRarity)
        {
            int level = levelOfRarity switch
            {
                "Common" => 1,
                "Uncommon" => 2,
                "Rare" => 3,
                "Epic" => 5,
                _=> 0
            };

            return level;
        }

        private int ChechLevelOfClarity(string levelOfClarity)
        {
            int level = levelOfClarity switch
            {
                "Chipped" => 1,
                "Regular" => 2,
                "Perfect" => 5,
                "Flwaless" => 10,
                _=> 0
            };

            return level;
        }
    }
}
