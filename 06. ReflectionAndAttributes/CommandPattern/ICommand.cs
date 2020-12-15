using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
