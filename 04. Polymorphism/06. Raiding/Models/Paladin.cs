using Raiding.Common;
using System;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            this.Power = GlobalConstants.PaladinPower;
        }

        //Paladin – "{Type} – {Name} healed for {Power}"
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
