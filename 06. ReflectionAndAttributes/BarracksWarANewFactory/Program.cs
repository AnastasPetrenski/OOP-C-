using BarracksWarANewFactory.Contracts;
using BarracksWarANewFactory.Core;
using BarracksWarANewFactory.Models;
using System;
using System.Linq;

namespace BarracksWarANewFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitFactory factory = new UnitFactory();
            Repository report = new Repository();
            Engine engine = new Engine(report, factory);
            engine.Run();
        }
    }
}
