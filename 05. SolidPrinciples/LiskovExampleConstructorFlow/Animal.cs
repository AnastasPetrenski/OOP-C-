
using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovExampleConstructorFlow
{
    public class Animal
    {
        public Animal(string name)
        {
            this.Name = name; //?? this.SetDefaultName();

            this.ValidateName();
        }

        public string Name { get; private set; }

        protected virtual void ValidateName()
        {
            if (this.Name.Length < 3)
            {
                throw new InvalidOperationException("Invalid name!");
            }
        }


        protected virtual string SetDefaultName()
        {
            return "Animal";
        }
    }
}
