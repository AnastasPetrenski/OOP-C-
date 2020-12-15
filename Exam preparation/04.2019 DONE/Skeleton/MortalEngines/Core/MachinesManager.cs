namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private ICollection<IPilot> pilots;
        private ICollection<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);

            if (this.pilots.Any(p => p.Name == name))
            {
                return String.Format(OutputMessages.PilotExists, name);
            }

            this.pilots.Add(pilot);

            return String.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(t => t.GetType() == typeof(Tank) && t.Name == name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return String.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(t => t.GetType() == typeof(Fighter) && t.Name == name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);

            string initialSetupAggresiveMode = fighter.AggressiveMode ? "ON" : "OFF";
            return String.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, initialSetupAggresiveMode);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            if (pilot == null)
            {
                return String.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (machine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return String.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return String.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            if (attacker == null)
            {
                return String.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            var defender = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);
            if (defender == null)
            {
                return String.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints <= 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defender.HealthPoints <= 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(defender);

            return String.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(m => m.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = this.machines.FirstOrDefault(m => m.GetType() == typeof(Fighter) && m.Name == fighterName) as Fighter;
            if (fighter == null)
            {
                return String.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();
            return String.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = this.machines.FirstOrDefault(m => m.GetType() == typeof(Tank) && m.Name == tankName) as Tank;
            if (tank == null)
            {
                return String.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();
            return String.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}