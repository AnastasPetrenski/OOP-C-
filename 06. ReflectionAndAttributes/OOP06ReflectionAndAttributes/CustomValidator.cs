using System.Collections.Generic;
using System.ComponentModel;

namespace OOP06ReflectionAndAttributes
{
    public class CustomValidator
    {
        private List<IComponent> components;

        public CustomValidator()
        {
            this.components = new List<IComponent>();
        }

        public IReadOnlyCollection<IComponent> Components
        {
            get => this.components.AsReadOnly();
            private set
            {
                this.Components = this.components;
            }
        }

        public void AddComponent(IComponent component)
        {
            
            this.components.Add(component);
        }
    }
}
