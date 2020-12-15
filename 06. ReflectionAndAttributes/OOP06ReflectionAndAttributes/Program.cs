using System;
using System.ComponentModel;

namespace OOP06ReflectionAndAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomValidator validator = new CustomValidator();
            IComponent component = null;
            Component comp = new Component();

            validator.AddComponent(component);
            validator.AddComponent(comp);
            var count = validator.Components.Count;
            
        }
    }

    class Component : IComponent
    {


        public ISite Site { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler Disposed;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
