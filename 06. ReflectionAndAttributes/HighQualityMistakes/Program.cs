using HighQualityMistakes.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HighQualityMistakes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("HighQualityMistakes.dll");

            foreach (var @class in assembly.GetTypes())
            {
                Console.WriteLine($"Class:{@class.Name}");
                foreach (var item in @class.GetProperties())
                {
                    Console.WriteLine(item.Name);
                }
            }

            var typeOfClassInstance = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Animal");

            //var instance = Activator.CreateInstance(typeOfClassInstance);
            //var instanceType = instance.GetType();
            //var anotherInstance = instance as Animal;
            //anotherInstance.Name = "Instance with property Name";

            Object o = Activator.CreateInstance(typeof(StringBuilder));
            IHuman humen = Activator.CreateInstance(typeof(Person), 33) as IHuman;

            Type typeCreator = typeof(Person);
            //var newinstance = Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase, typeCreator.Name);

            Type compileType = typeof(Animal);
            Animal animal = Activator.CreateInstance(compileType, new Object[] { "Nasko", 2}) as Animal;
            Console.WriteLine(animal.GetType().Name);
            Type type = animal.GetType();
            var allPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            var allPrivateMethod = compileType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            string input = Console.ReadLine();
            Type runtimePathType = Type.GetType("HighQualityMistakes.Person");
            IHuman person = Activator.CreateInstance(runtimePathType, input) as Person;
            Console.WriteLine($"{person.GetType()} - {person.Name}");

            Type baseType = runtimePathType.BaseType;
            Console.WriteLine($"base class name -> {baseType}");
            var constructors = runtimePathType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            Type[] interfaces = baseType.GetInterfaces();
            var fields = baseType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
            foreach (var item in fields)
            {
                if (item.IsLiteral)
                {
                    if (!results.ContainsKey("IsLiteral"))
                    {
                        results.Add("IsLiteral", new List<string>());
                    }
                    results["IsLiteral"].Add(item.Name);
                }
                if (item.IsInitOnly)
                {
                    if (!results.ContainsKey("IsInitOnly"))
                    {
                        results.Add("IsInitOnly", new List<string>());
                    }
                    results["IsInitOnly"].Add(item.Name);
                }
                if (item.IsPrivate)
                {
                    if (!results.ContainsKey("IsPrivate"))
                    {
                        results.Add("IsPrivate", new List<string>());
                    }
                    results["IsPrivate"].Add(item.Name);
                }
                if (item.IsPublic)
                {
                    if (!results.ContainsKey("IsPublic"))
                    {
                        results.Add("IsPublic", new List<string>());
                    }
                    results["IsPublic"].Add(item.Name);
                }
                if (item.IsStatic)
                {
                    if (!results.ContainsKey("IsStatic"))
                    {
                        results.Add("IsStatic", new List<string>());
                    }
                    results["IsStatic"].Add(item.Name);
                }
                if (item.IsFamily)
                {
                    if (!results.ContainsKey("IsFamily"))
                    {
                        results.Add("IsFamily", new List<string>());
                    }
                    results["IsFamily"].Add(item.Name);
                }
                if (item.IsAssembly)
                {
                    if (!results.ContainsKey("IsAssembly"))
                    {
                        results.Add("IsAssembly", new List<string>());
                    }
                    results["IsAssembly"].Add(item.Name);
                }
            }

            foreach (var item in results)
            {
                Console.WriteLine($"---->   {item.Key}");
                Console.WriteLine(string.Join(", ", item.Value));
            }

            var methods = runtimePathType.GetMethods();
            foreach (var method in methods)
            {
                Console.Write(method.Name + " -> ");
                var parames = method.GetParameters();
                foreach (var item in parames)
                {
                    Console.WriteLine($"{item.Name} - {item.ParameterType}");
                }
                Console.WriteLine();
            }

            var currMethod = runtimePathType.GetMethod("Print");
            var currMethodArgs = currMethod.GetParameters();

            Type returnType = currMethod.ReturnType;


            object obj = new object();
            int a = 1;
            int b = 2;
            string[] numbers = new string[] { "1", "2", "3", "4" };

            var x = currMethod.Invoke(person, new object[] { a, b, numbers });
            Console.WriteLine(x);

            string inputType = Console.ReadLine();
            Type runtimeType = Type.GetType(inputType);
            IHuman newPerson = Activator.CreateInstance(runtimeType, "Pesho") as Person;

        }
    }
}
