using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Contracts
{
    public interface IGem
    {
        int Strength { get; }

        int Agiity { get; }

        int Vitality { get; }

        string LevelOfClarity { get; }
    }
}
