using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Commands
{
    public abstract class Command : ICommand
    {
        public IList<string> Arguments => throw new NotImplementedException();

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
