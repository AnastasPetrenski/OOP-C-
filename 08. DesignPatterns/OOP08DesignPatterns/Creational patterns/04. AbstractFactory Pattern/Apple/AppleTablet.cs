using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Apple
{
    public class AppleTablet : ITablet
    {
        public string OS => "iOS";
    }
}
