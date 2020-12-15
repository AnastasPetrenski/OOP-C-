using MXGP.Models.Riders.Contracts;
using System;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        protected override Func<IRider, bool> GetModelByName(string name)
        {
            return (x) => x.Name == name;
        }
    }
}
