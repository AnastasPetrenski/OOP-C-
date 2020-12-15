using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Components.Contracts;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Computers.Contracts;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Peripherals.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        private IComputer ValidateComputer(int id)
        {
            var comp = this.computers.FirstOrDefault(c => c.Id == id);
            if (comp == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return comp;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var comp = ValidateComputer(computerId);

            var exist = components.FirstOrDefault(c => c.Id == id);
            if (exist != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            Enum.TryParse(componentType, out ComponentType result);

            IComponent component = result switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _=> throw new ArgumentException("Component type is invalid.")
            };

            comp.AddComponent(component);
            components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }
        //DONT check computer, with that id, exists in the computers collection
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            var existed = computers.FirstOrDefault(c => c.Id == id);
            if (existed != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            Enum.TryParse(computerType, out ComputerType result);

            IComputer computer = result switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException("Computer type is invalid.")
            };

            computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var comp = ValidateComputer(computerId);

            var exist = peripherals.FirstOrDefault(c => c.Id == id);
            if (exist != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            Enum.TryParse(peripheralType, out PeripheralType result);

            IPeripheral peripheral = result switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _=> throw new ArgumentException("Peripheral type is invalid.")
            };

            comp.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computerId}.";
        }
        //DONT check computer, with that id, exists in the computers collection
        public string BuyBest(decimal budget)
        {
            var comp = computers
                .Where(c => c.Price <= budget)
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault();

            if (comp == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            var output = comp.ToString();
            computers.Remove(comp);

            return output;
        }

        public string BuyComputer(int id)
        {
            var comp = ValidateComputer(id);

            var ouput = comp.ToString();

            computers.Remove(comp);

            return ouput;
        }

        public string GetComputerData(int id)
        {
            var comp = ValidateComputer(id);

            return comp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var comp = ValidateComputer(computerId);

            var component = comp.RemoveComponent(componentType);

            components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var comp = ValidateComputer(computerId);

            var peripheral = comp.RemovePeripheral(peripheralType);

            peripherals.Remove(peripheral);

            return $"Successfully removed {peripheral.GetType().Name} with id {peripheral.Id}.";
        }
    }
}
