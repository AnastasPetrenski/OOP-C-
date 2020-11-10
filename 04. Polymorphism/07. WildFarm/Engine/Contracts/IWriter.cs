using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Engine.Contracts
{
    public interface IWriter
    {
        public void Write(string text);

        public void WriteLine(string text);

        public void WriteLine();
    }
}
