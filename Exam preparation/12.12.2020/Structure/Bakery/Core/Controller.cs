using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal total;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.total = 0;
        }

        private ITable TableFactory(string type, int tableNumber, int capacity)
        {
            Enum.TryParse(type, out TableType result);
            ITable table = result switch
            {
                TableType.InsideTable => new InsideTable(tableNumber, capacity),
                TableType.OutsideTable => new OutsideTable(tableNumber, capacity),
                _ => null
            };

            return table;
        }

        private IBakedFood FoodFactory(string type, string name, decimal price)
        {
            Enum.TryParse(type, out BakedFoodType result);
            IBakedFood food = result switch
            {
                BakedFoodType.Bread => new Bread(name, price),
                BakedFoodType.Cake => new Bread(name, price),
                _ => null
            };

            return food;
        }

        private IDrink DrinkFactory(string type, string name, int portion, string brand)
        {
            Enum.TryParse(type, out DrinkType result);
            IDrink drink = result switch
            {
                DrinkType.Tea => new Tea(name, portion, brand),
                DrinkType.Water => new Water(name, portion, brand),
                _ => null
            };

            return drink;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            var drink = DrinkFactory(type, name, portion, brand);

            this.drinks.Add(drink);

            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = FoodFactory(type, name, price);

            if (food == null)
            {
                return "";
            }

            this.bakedFoods.Add(food);

            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var table = TableFactory(type, tableNumber, capacity);

            this.tables.Add(table);

            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var tablesFree = this.tables.Where(t => t.IsReserved == false).ToList();
            var sb = new StringBuilder();

            foreach (var table in tablesFree)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return String.Format($"Total income: {this.total:f2}lv");
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var sb = new StringBuilder();
            if (table != null)
            {
                decimal bill = table.GetBill();
                this.total += bill;
                table.Clear();

                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {bill:f2}");
            }
           

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return String.Format($"Table {tableNumber} ordered {drinkName} {drinkBrand}");
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
