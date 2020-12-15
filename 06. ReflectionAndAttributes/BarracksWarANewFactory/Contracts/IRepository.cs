using BarracksWarANewFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Contracts
{
    public interface IRepository
    {
        void Add(IUnit unit);
        string Report();
        string Retire(string name);
    }
}
