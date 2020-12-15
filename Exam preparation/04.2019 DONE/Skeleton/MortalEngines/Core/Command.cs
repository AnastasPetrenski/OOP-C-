using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Command : ICommand
    {
        private string commandType;
        private string[] arguments;
        private IMachinesManager manager;

        public Command(string commandType, string[] arguments, IMachinesManager manager)
        {
            this.commandType = commandType;
            this.arguments = arguments;
            this.manager = manager;
        }

        public string Execute()
        {
            string message = string.Empty;
            try
            {
                message = this.commandType switch
                {
                    "HirePilot" => this.manager.HirePilot(arguments[0]),
                    "PilotReport" => this.manager.PilotReport(arguments[0]),
                    "ManufactureTank" => this.manager.ManufactureTank(arguments[0], double.Parse(arguments[1]), double.Parse(arguments[2])),
                    "ManufactureFighter" => this.manager.ManufactureFighter(arguments[0], double.Parse(arguments[1]), double.Parse(arguments[2])),
                    "MachineReport" => this.manager.MachineReport(arguments[0]),
                    "AggressiveMode" => this.manager.ToggleFighterAggressiveMode(arguments[0]),
                    "DefenseMode" => this.manager.ToggleTankDefenseMode(arguments[0]),
                    "Engage" => this.manager.EngageMachine(arguments[0], arguments[1]),
                    "Attack" => this.manager.AttackMachines(arguments[0], arguments[1]),
                    _=> null
                };
            }
            catch (Exception e)
            {
                message = $"Error: {e.Message}";
            }

            return message;
        }
    }
}
