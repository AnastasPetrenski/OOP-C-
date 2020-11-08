using Raiding.Common;
using System;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = GlobalConstants.DruidPower;
        }

        //Druid – "{Type} – {Name} healed for {Power}"
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
