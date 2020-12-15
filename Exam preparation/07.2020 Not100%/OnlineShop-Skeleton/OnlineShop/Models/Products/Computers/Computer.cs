using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components.Contracts;
using OnlineShop.Models.Products.Computers.Contracts;
using OnlineShop.Models.Products.Peripherals.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            
        }

        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();


        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(c => c.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var existedUnit = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (this.components.Count == 0 || existedUnit == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, nameof(componentType), this.GetType().Name, this.Id));
            }

            this.components.Remove(existedUnit);

            return existedUnit;
        }
        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var existedUnit = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            if (this.peripherals.Count == 0 || existedUnit == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, nameof(peripheralType), this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(existedUnit);

            return existedUnit;
        }

        public override double OverallPerformance => this.Components.Count > 0
                ? this.Components.Average(x => x.OverallPerformance) + base.OverallPerformance 
                : base.OverallPerformance;
        //{
        //    get => this.OverallPerformance;
        //    protected set
        //    {
        //        if (this.Components.Count > 0)
        //        {
        //            var average = this.Components.Average(x => x.OverallPerformance);
        //            this.OverallPerformance = base.OverallPerformance + average;
        //        }
        //        else
        //        {
        //            this.OverallPerformance = base.OverallPerformance;
        //        }
        //    }
        //}

        public override decimal Price => base.Price +
            this.components.Sum(c => c.Price) +
            this.peripherals.Sum(p => p.Price);
       
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var item in this.Components)
            {
                sb.AppendLine($"  {item}");
            }

            var averagePeropherals = this.Peripherals.Count > 0 ? this.Peripherals.Average(p => p.OverallPerformance) : 0;
            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({averagePeropherals:f2}):");

            foreach (var item in this.Peripherals)
            {
                sb.AppendLine($"  {item}");
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }
}
