using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts
{
    public interface IHeadSet
    {
        int Size { get; }

        int Volume { get; set; }

        void DecreaseVolume();

        void IncreaseVolume();
    }
}
