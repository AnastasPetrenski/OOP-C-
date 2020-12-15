using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {
        }

        public IHarvesterController HarvesterController => throw new NotImplementedException();

        public IProviderController ProviderController => throw new NotImplementedException();

        public string ProcessCommand(IList<string> args)
        {
            throw new NotImplementedException();
        }
    }
}
