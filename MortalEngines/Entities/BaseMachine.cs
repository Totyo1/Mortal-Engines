using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;


namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defencePoints;
        private double healthPoints;
        private List<string> targets;



        protected BaseMachine(string name, double attackPoints, double defencePoints, double healthPoints)
        {
            this.Name = name;
            this.Pilot = pilot;
            this.AttackPoints = attackPoints;
            this.defencePoints = defencePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                this.pilot = value ?? throw new NullReferenceException("Pilot cannot be null.");
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                if (value > 0)
                {
                    healthPoints = value;
                }
            }
        }

        public double AttackPoints
        {
            get => this.attackPoints;
            protected set
            {
                if (value > 0)
                {
                    this.attackPoints = value;
                }
            }
        }

        public double DefensePoints
        {
            get => this.defencePoints;
            protected set
            {
                if (value > 0)
                {
                    this.defencePoints = value;
                }

            }
        }

        public IList<string> Targets => targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            if (this.attackPoints - target.DefensePoints > 0)
            {
                target.HealthPoints -= (this.AttackPoints - target.DefensePoints);
            }
            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.name}");
            
            sb.AppendLine($" *Type: {this.GetType().UnderlyingSystemType}");
            sb.AppendLine($" *Health: {this.healthPoints}");
            sb.AppendLine($" *Attack: { this.AttackPoints}");
            sb.AppendLine($"Defense: {this.defencePoints}");
            if (targets.Count == 0)
            {
                sb.Append("Targets: None");
            }
            else
            {
                sb.Append(string.Join(",", targets));
            }

            return sb.ToString().TrimEnd(',');
        }
    }
}
