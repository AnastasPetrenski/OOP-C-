using Raiding.Common;
using System;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            this.Power = GlobalConstants.DamagePower;
        }

        //Rogue – "{Type} – {Name} hit for {Power} damage"
        public override string CastAbility()
        {
            return String.Format(GlobalConstants.DamageHerosMsg, this.GetType().Name, Name, Power);
        }
    }
}
