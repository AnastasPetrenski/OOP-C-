using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Dictionary<string, IProcedure> procedures; 

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>();
            this.CreateProcedure();
        }

        private void CreateProcedure()
        {
            this.procedures.Add("Chip", new Chip());
            this.procedures.Add("Polish", new Polish());
            this.procedures.Add("Rest", new Rest());
            this.procedures.Add("Charge", new Charge());
            this.procedures.Add("TechCheck", new TechCheck());
            this.procedures.Add("Work", new Work());
        }

        private IRobot ValidateRobot(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;
        }

        public string Charge(string robotName, int procedureTime)
        {
            var robot = ValidateRobot(robotName);

            var procedure = this.procedures["Charge"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            var robot = ValidateRobot(robotName);

            var procedure = this.procedures["Chip"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var sb = new StringBuilder();

            return this.procedures[procedureType].History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {

            IRobot robot = robotType switch
            {
                "HouseholdRobot" => new HouseholdRobot(name, energy, happiness, procedureTime),
                "WalkerRobot" => new WalkerRobot(name, energy, happiness, procedureTime),
                "PetRobot" => new PetRobot(name, energy, happiness, procedureTime),
                _=> throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType))
            };

            this.garage.Manufacture(robot);

            return String.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            var robot = ValidateRobot(robotName);

            var procedure = this.procedures["Polish"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            var robot = ValidateRobot(robotName);

            var procedure = this.procedures["Rest"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            var robot = ValidateRobot(robotName);

            this.garage.Sell(robotName, ownerName);

            return robot.IsChipped 
                ? String.Format(OutputMessages.SellChippedRobot, ownerName) 
                : String.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var robot = ValidateRobot(robotName);

            var procedure = this.procedures["TechCheck"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            var robot = ValidateRobot(robotName);

            var procedure = this.procedures["Work"];

            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }
    }
}
