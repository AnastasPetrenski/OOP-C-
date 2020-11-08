using Raiding.Common;
using System;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = GlobalConstants.DamagePower;
        }

        //override
        public override string CastAbility()
        {
            return String.Format(GlobalConstants.DamageHerosMsg, this.GetType().Name, Name, Power);
        }
    }
}
