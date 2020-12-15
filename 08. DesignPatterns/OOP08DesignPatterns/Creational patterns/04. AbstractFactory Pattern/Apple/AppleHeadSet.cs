using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Apple
{
    public class AppleHeadSet : IHeadSet
    {

        public AppleHeadSet()
        {
            this.Size = 2;
            this.Volume = 10;
        }

        public int Size { get; }

        public int Volume { get ; set ; }

        public void DecreaseVolume()
        {
            if (this.Volume - 1 >= 0)
            {
                this.Volume -= 1;
            }
        }

        public void IncreaseVolume()
        {
            if (this.Volume + 1 <= 100)
            {
                this.Volume += 1;
            }
        }
    }
}
