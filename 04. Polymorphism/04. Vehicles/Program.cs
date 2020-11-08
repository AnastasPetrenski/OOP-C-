using System;
using Vehicles.Models;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = ReadInput();
            Car car = new Car(double.Parse(input[1]), double.Parse(input[2]));
            input = ReadInput();
            Truck truck = new Truck(double.Parse(input[1]), double.Parse(input[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = ReadInput();
                string command = input[0];
                string type = input[1];
                double distance = double.Parse(input[2]);

                switch (type)
                {
                    case nameof(Car):
                        ExecuteCommand(car, command, distance);
                        break;
                    case nameof(Truck):
                        ExecuteCommand(truck, command, distance);
                        break;
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
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
