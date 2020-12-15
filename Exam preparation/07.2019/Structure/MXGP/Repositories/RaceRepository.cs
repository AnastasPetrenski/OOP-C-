using MXGP.Models.Races.Contracts;
using System;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        protected override Func<IRace, bool> GetModelByName(string name)
        {
            return (x) => x.Name == name;
        }
    }
}
