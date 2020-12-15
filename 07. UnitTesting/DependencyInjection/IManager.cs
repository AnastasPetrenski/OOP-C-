using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IManager
    {
        string Name { get; }

        string Position { get; }
    }
}
