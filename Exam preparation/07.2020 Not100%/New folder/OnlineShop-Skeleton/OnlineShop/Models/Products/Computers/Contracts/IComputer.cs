using OnlineShop.Models.Products.Components.Contracts;
using OnlineShop.Models.Products.Contracts;
using OnlineShop.Models.Products.Peripherals.Contracts;
using System.Collections.Generic;

namespace OnlineShop.Models.Products.Computers.Contracts
{
    public interface IComputer : IProduct
    {
        IReadOnlyCollection<IComponent> Components { get; }

        IReadOnlyCollection<IPeripheral> Peripherals { get; }

        void AddComponent(IComponent component);

        IComponent RemoveComponent(string componentType);

        void AddPeripheral(IPeripheral peripheral);

        IPeripheral RemovePeripheral(string peripheralType);
    }
}
