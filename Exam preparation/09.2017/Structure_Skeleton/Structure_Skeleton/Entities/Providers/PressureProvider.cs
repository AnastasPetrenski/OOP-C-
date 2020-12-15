using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Entities.Providers
{
    public class PressureProvider : Provider
    {
        private const double InitialDurabilityDecrease = 300;
        private const int EnergyOutputMultiplier = 2;

        public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
        {
            this.EnergyOutput *= EnergyOutputMultiplier;
            this.Durability -= InitialDurabilityDecrease;
        }
    }
}
