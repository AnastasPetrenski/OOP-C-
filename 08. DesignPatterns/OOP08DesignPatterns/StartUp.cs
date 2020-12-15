
using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Apple;
using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts;
using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Factories;
using OOP08DesignPatterns.Creational_patterns._05._Builder_Pattern;
using OOP08DesignPatterns.Creational_patterns._06._FluentInterface_Pattern;
using OOP08DesignPatterns.Creational_patterns._07._Prototype_pattern;
using OOP08DesignPatterns.Creational_patterns._09._Lazy_Initialization_Pattern;
using OOP08DesignPatterns.Creational_patterns.Singleton_Pattern;

namespace OOP08DesignPatterns
{
    class StartUp
    {
        static void Main()
        {
            var instance = Singleton.Instance;

            instance.LogToFile();

            Singleton.Instance.LogToFile();

            //Abstract Factory Example
            System.Console.WriteLine("Abstract Factory Example");
            bool isAnswerTrue = 1 > 2 ? true : false;

            ITech factory = null;
            
            if (isAnswerTrue)
            {
                factory = new AppleFactory();
            }
            else
            {
                factory = new SamsungFactory();
            }

            ITablet tablet = factory.CreateTablet();
            IMobilePhone phone = factory.CreatePhone();
            IHeadSet headset = factory.CreateHeadSet();

            try
            {
                phone.AddContact("Nasko", "0895600047");
                System.Console.WriteLine(tablet.OS);
                System.Console.WriteLine(tablet.GetType().Name);
                System.Console.WriteLine(phone.GetType().Name);
                System.Console.WriteLine(headset.GetType().Name);
                headset.DecreaseVolume();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.WriteLine(headset.Volume);
            
            phone.MakeCall(0895600047);
            phone.AddContact("Nasko", "0895600000");
            phone.MakeCall(0895600000);

            //Builder pattern
            System.Console.WriteLine("Builder pattern example");
            Car car = new Car();
            CarBuilder carBuilder = new CarBuilder();
            carBuilder.BuildTyres(car);
            carBuilder.BuildEngine(car);
            carBuilder.BuildGear(car);

            System.Console.WriteLine($"car:{car.Engine}, car:{car.Gear}, car:{car.Tyres}");

            //FluentInterface pattern
            System.Console.WriteLine("Fluent Interface pattern example");
            CarFluent carFluent = new CarFluent();
            CarBuilderFluent carBuilderFluent = new CarBuilderFluent();
            carBuilderFluent
                .BuildTyres(carFluent)
                .BuildEngine(carFluent)
                .BuildGear(carFluent);

            System.Console.WriteLine($"car:{carFluent.Engine}, car:{carFluent.Gear}, car:{carFluent.Tyres}");

            //Prototype pattern
            Country country = new Country("Bulgaria");
            City city = new City("Sofia");
            Address address = new Address(country, city) { Street = "Sofia 1000"};
            System.Console.WriteLine(address);

            //Shallow copy - if we have referent type member, both objects will point to the same address in the heap
            //for example City is referent type, so copy will change the name for both object
            //Street is premitive type, so copy will change only its street's value 
            Address shallowCopy = (Address)address.Clone(address);
            shallowCopy.Street = "Petrich 2850";
            shallowCopy.City.Name = "Petrich";

            System.Console.WriteLine(shallowCopy);

            Address deepCopy = (Address)address.Clone();
            //deepCopy.City = address.City.Clone() as City;
            //deepCopy.Country = address.Country.Clone() as Country;
            deepCopy.City.Name = "Paris";
            deepCopy.Country.Name = "France";
            deepCopy.Street = "ShanZelize 9000";

            System.Console.WriteLine(address);
            System.Console.WriteLine(deepCopy);

            //LazyLoading
            EngineBank engine = new EngineBank();
            engine.Run();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Solution
//{
//    public class Note
//    {
//        private string state;
//        private string name;

//        public Note(String state, String name)
//        {
//            this.Name = name;
//            this.State = state;
//        }

//        public string Name  
//        {
//            get => this. name;
//            set
//            {
//                if (String.IsNullOrEmpty(value))
//                {
//                    throw new Exception("Name cannot be empty");
//                }
//                this.name = value;
//            }

//        }

//        public string State
//        {
//            get => state;
//            set
//            {
//                if (value != "completed" && value != "active" && value != "others")
//                {
//                    throw new Exception($"Invalid state {value}");
//                }
//                this.state = value;
//            }
//        }
//    }

//    public class NotesStore
//    {
//        public List<Note> notes { get; set; }

//        public NotesStore()
//        {
//            this.notes = new List<Note>();
//        }

//        public void AddNote(String state, String name)
//        {
//            Note note = new Note(state.ToLower(), name);
//            this.notes.Add(note);
//        }
//        public List<String> GetNotes(String state)
//        {

//            if (state.ToLower() != "completed" && state.ToLower() != "active" && state.ToLower() != "others")
//            {
//                throw new Exception($"Invalid state {state}");
//            }

//            var list = this.notes.Where(n => n.State == state.ToLower()).Select(n => n.Name).ToList();

//            return list;
//        }
//    }

//    public class Solution
//    {
//        public static void Main()
//        {
//            var notesStoreObj = new NotesStore();
//            var n = int.Parse(Console.ReadLine());
//            for (var i = 0; i < n; i++)
//            {
//                var operationInfo = Console.ReadLine().Split(' ');
//                try
//                {
//                    if (operationInfo[0] == "AddNote")
//                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
//                    else if (operationInfo[0] == "GetNotes")
//                    {
//                        var result = notesStoreObj.GetNotes(operationInfo[1]);
//                        if (result.Count == 0)
//                            Console.WriteLine("No Notes");
//                        else
//                            Console.WriteLine(string.Join(",", result));
//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid Parameter");
//                    }
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("Error: " + e.Message);
//                }
//            }
//        }
//    }
//}
