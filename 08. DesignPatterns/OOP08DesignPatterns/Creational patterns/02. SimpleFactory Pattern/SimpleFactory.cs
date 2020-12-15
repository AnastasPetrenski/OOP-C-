namespace OOP08DesignPatterns.Creational_patterns.SimpleFactory_Pattern
{
    public class SimpleFactory
    {
        public IAnimal CreateAnimal(string name)
        {
            IAnimal animal = name switch
            {
                "Monkey" => new Monkey(name),
                "Bear" => new Bear(name),
                _ => null
            };

            return animal;
        }
    }
}
