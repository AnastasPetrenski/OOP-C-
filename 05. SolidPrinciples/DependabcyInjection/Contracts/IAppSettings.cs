using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Contracts
{
    public interface IAppSettings
    {
        public string ConnectionString { get; }
    }
}
