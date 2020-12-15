using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Components.Contracts;
using OnlineShop.Models.Products.Computers.Contracts;
using OnlineShop.Models.Products.Computers.Entities;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Peripherals.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var comp = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (comp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            //TODO ComponentFactory
            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component =  typeOfComponent switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            comp.AddComponent(component);

            this.components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            Enum.TryParse(computerType, out ComputerType typeOfComputer);
            IComputer computer = typeOfComputer switch
            {
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            this.computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            Enum.TryParse(peripheralType, out PeripheralType typeOfPeripheral);
            IPeripheral peripheral = typeOfPeripheral switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            this.computers
                .FirstOrDefault(c => c.Id == computerId)
                .AddPeripheral(peripheral);

            this.peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0 || !this.computers.Any(c => c.Price <= budget))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var bestBuy = this.components.Where(c => c.Price <= budget).OrderByDescending(c => c.OverallPerformance).ThenByDescending(c => c.Price).FirstOrDefault();

            this.components.Remove(bestBuy);

            return bestBuy.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var comp = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(comp);

            return comp.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var comp = this.computers.FirstOrDefault(c => c.Id == id);

            return comp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var removedComponent = this.computers.FirstOrDefault(c => c.Id == computerId).RemoveComponent(componentType);

            this.components.Remove(removedComponent);

            return String.Format(SuccessMessages.RemovedComponent, componentType, removedComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var removedPeripheral = this.computers.FirstOrDefault(c => c.Id == computerId).RemovePeripheral(peripheralType);

            this.peripherals.Remove(removedPeripheral);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, removedPeripheral.Id);
        }
    }
}
