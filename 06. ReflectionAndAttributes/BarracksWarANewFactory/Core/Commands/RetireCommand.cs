using BarracksWarANewFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            return this.Repository.Retire(unitType);
        }
    }
}
