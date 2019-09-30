using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Contracts
{
    public class Pilot : IPilot
    {
        private string name;
        private  Dictionary<string, IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new Dictionary<string, IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {

            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            else
            {
                this.machines.Add(machine.Name, machine);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.name}-{this.machines.Count}machines");
            sb.AppendLine();
            foreach (var machine in machines)
            {
                sb.AppendLine($"- {machine.Key}");
                sb.AppendLine($"*Type: {machine.Value.GetType()}");
                sb.AppendLine($"*Health: {machine.Value.HealthPoints}");
                sb.AppendLine($"*Attack: {machine.Value.AttackPoints}");
                sb.AppendLine($"Defense: {machine.Value.DefensePoints}");
                sb.AppendLine($"*Targets: {string.Join(", ", machine.Value.Targets)}");
            }
            return sb.ToString().Trim();
        }
    }
}
