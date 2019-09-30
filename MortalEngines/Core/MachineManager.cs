using System;
using System.Collections.Generic;
using MortalEngines.Core.Contracts;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.Common;

namespace MortalEngines.Core
{
    class MachineManager : IMachinesManager
    {
        private Dictionary<string, IPilot> pilots = new Dictionary<string, IPilot>();
        private Dictionary<string, IMachine> machines = new Dictionary<string, IMachine>();
       
        public string HirePilot(string name)
        {
            if (pilots.ContainsKey(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                Pilot pilot = new Pilot(name);
                pilots.Add(name, pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots[pilotReporting].Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines[machineName].ToString();
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var tank = new Tank(name, attackPoints, defensePoints);
                machines.Add(name, tank);
                return string.Format(OutputMessages.TankManufactured, name, attackPoints, defensePoints);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (machines.ContainsKey(tankName) && machines[tankName] is Tank tank)
            {
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var fighter = new Fighter(name, attackPoints, defensePoints);
                machines.Add(name, fighter);
                return string.Format(OutputMessages.FighterManufactured, name, attackPoints, defensePoints);
            }
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (machines.ContainsKey(fighterName) && machines[fighterName] is Fighter fighter)
            {
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful);
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!pilots.ContainsKey(selectedPilotName))
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (!machines.ContainsKey(selectedMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (machines[selectedMachineName].Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!machines.ContainsKey(attackingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (!machines.ContainsKey(defendingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (machines[attackingMachineName].HealthPoints < 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (machines[defendingMachineName].HealthPoints < 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            machines[attackingMachineName].Attack(machines[defendingMachineName]);
            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, machines[defendingMachineName].HealthPoints);
            
        }
    }
}
