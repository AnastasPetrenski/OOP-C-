using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class JuniorManager : IManager
    {
        public JuniorManager(string name, string position)
        {
            this.Name = name;
            this.Position = position;
        }

        public string Name { get; private set; }

        public string Position { get; private set; }

    }
}
