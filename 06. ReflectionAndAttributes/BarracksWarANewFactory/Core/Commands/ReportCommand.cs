using BarracksWarANewFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Core.Commands
{
    class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            return this.Repository.Report();
        }
    }
}
