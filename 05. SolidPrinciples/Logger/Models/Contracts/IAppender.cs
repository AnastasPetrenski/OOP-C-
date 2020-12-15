using Logger.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        long MessegesAppended { get; }

        void Append(IError error);
    }
}
