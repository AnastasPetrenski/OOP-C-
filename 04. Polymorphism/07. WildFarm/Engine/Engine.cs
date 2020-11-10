using System.Collections.Generic;
using WildFarm.Models;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Engine
{
    public class Engine
    {
        private ICollection<Animal> animals;
        private ConsoleReader reader;
        private ConsoleWriter writer;

        public Engine()
        {
            animals = new List<Animal>();
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
        }

        //public ICollection<Animal> Animals { get; private set; }

        public void Run()
        {
            string command = string.Empty;
            while ((command = reader.ReadLine()) != "End")
            {
                var animalArgs = command.Split();

                Animal animal = animalArgs[0] switch
                {
                    nameof(Cat) => new Cat(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]),
                    nameof(Dog) => new Dog(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]),
                    nameof(Hen) => new Hen(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3])),
                    nameof(Mouse) => new Mouse(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]),
                    nameof(Owl) => new Owl(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3])),
                    nameof(Tiger) => new Tiger(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]),
                    _=> null
                };

                writer.WriteLine(animal.EatingSound());

                var foodArgs = reader.ReadLine().Split();

                Food food = foodArgs[0] switch
                {
                    nameof(Fruit) => new Fruit(int.Parse(foodArgs[1])),
                    nameof(Meat) => new Meat(int.Parse(foodArgs[1])),
                    nameof(Seeds) => new Seeds(int.Parse(foodArgs[1])),
                    nameof(Vegetable) => new Vegetable(int.Parse(foodArgs[1])),
                    _ => null
                };

                try
                {
                    animal.TryFeeding(food);
                }
                catch (System.Exception e)
                {
                    writer.WriteLine(e.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
            
        }

    }
}
