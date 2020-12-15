using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts;
using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Samsung;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Factories
{
    public class SamsungFactory : ITech
    {
        public IMobilePhone CreatePhone()
        {
            return new SamsungPhone();
        }

        public ITablet CreateTablet()
        {
            return new SamsungTablet();
        }

        public IHeadSet CreateHeadSet()
        {
            return new SamsungHeadSet();
        }
    }
}
