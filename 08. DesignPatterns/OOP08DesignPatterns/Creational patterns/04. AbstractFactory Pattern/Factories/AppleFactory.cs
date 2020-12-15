using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Apple;
using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Factories
{
    public class AppleFactory : ITech
    {
        public IMobilePhone CreatePhone()
        {
            return new ApplePhone();
        }

        public ITablet CreateTablet()
        {
            return new AppleTablet();
        }

        public IHeadSet CreateHeadSet()
        {
            return new AppleHeadSet();
        }
    }
}
