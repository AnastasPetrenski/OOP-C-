using Raiding.Common;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Raiding.Core
{
    public class Engine
    {
        public Engine()
        {
            this.Raiders = new List<BaseHero>();
        }

        public readonly ICollection<BaseHero> Raiders;

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while (Raiders.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = GenerateHero(heroName, heroType);
                if (hero != null)
                {
                    Raiders.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int commonPower = 0;

            foreach (var hero in Raiders)
            {
                Console.WriteLine(hero.CastAbility());
                commonPower += hero.Power;
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (commonPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
        private BaseHero GenerateHero(string heroName, string heroType)
        {
            BaseHero hero = heroType switch
            {
                nameof(Druid) => new Druid(heroName),
                nameof(Paladin) => new Paladin(heroName),
                nameof(Rogue) => new Rogue(heroName),
                nameof(Warrior) => new Warrior(heroName),
                _ => null
            };

            return hero;
        }
    }
}
