using System;

using MyLogger.Models.Enumerator;

namespace MyLogger.Models.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
