using HighQualityMistakes.Constracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighQualityMistakes
{
    public abstract class Human : IHuman
    {
        private const int height = 160;
        public readonly ICollection<Human> persons; 
        private string name = "Nasko";
        protected int age;
        internal string family;

        private Human()
        {
            this.persons = new List<Human>();
        }

        public Human(string name) : this()
        {
            this.Name = name;
        }

        protected Human(int age) 
        {
            this.age = age;
        }

        static Human()
        {

        }

        public string Name { get; private set;}

        protected int Age => this.age;

        int IHuman.Age => this.Age;

        public abstract void Run();
        
    }
}
