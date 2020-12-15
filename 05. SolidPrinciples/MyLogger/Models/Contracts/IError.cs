using MyLogger.Models.Enumerator;
using System;

namespace MyLogger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        Level Level { get; }

        string Message { get; }
    }
}
