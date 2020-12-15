using System;
using System.Collections.Generic;
using System.Text;

namespace HighQualityMistakes.Constracts
{
    public interface IHuman
    {
        string Name { get; }

        int Age { get; }

        abstract void Run();
    }
}
