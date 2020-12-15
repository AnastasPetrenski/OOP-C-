using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class SiniorManager : IManager
    {
        public SiniorManager(string name, string position)
        {
            this.Name = name;
            this.Position = position;
        }



        public string Name { get; private set; }

        public string Position { get; private set; }

        public void SetLevel(IManager manager)
        {

        }
    }
}
