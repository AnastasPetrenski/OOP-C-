using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Contracts
{
    public interface IRandomProvider
    {
        int Number(int min, int max);
    }
}
