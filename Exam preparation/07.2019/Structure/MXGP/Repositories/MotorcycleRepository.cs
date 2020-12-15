using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        protected override Func<IMotorcycle, bool> GetModelByName(string name)
        {
            return (x) => x.Model == name;
        }
    }
}
