using System;
using Vehicles.Models;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            var input = ReadInput();
            Car car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            input = ReadInput();
            Truck truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            input = ReadInput();
            Bus bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = ReadInput();
                string command = input[0];
                string type = input[1];
                double distance = double.Parse(input[2]);
                try
                {
                    switch (type)
                    {
                        case nameof(Car):
                            ExecuteCommand(car, command, distance);
                            break;
                        case nameof(Truck):
                            ExecuteCommand(truck, command, distance);
                            break;
                        case nameof(Bus):
                            ExecuteCommand(bus, command, distance);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            bool isEmpty = false;
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value, isEmpty));
                    break;
                case "DriveEmpty":
                    isEmpty = true;
                    Console.WriteLine(vehicle.Drive(value, isEmpty));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }

        public static string[] ReadInput()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return input;
        }
    }
}
