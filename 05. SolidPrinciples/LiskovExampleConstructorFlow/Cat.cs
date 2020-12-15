using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovExampleConstructorFlow
{
    public class Cat : Animal
    {
        public Cat(string name = null) : base(name)
        {

        }

        //IF we override the method we will violation the Liskov Substitution

        protected override void ValidateName()
        {

        }

        protected override string SetDefaultName()
        {
            return "Cat";
            //throw new InvalidOperationException("No default name for animal");
        }
    }
}
