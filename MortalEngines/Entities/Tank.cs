using System;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    class Tank : BaseMachine, ITank
    {
        private const double ATTACK = 40.0;
        private const double DEFENCE = 30.0;
        private const double initialHP = 100.0;

        public Tank(string name, double attackPoints, double defencePoints)
            : base(name, attackPoints, defencePoints, initialHP)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }
        
        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints -= ATTACK;
                this.DefensePoints += DEFENCE;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints += ATTACK;
                this.DefensePoints -= DEFENCE;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine();
            sb.AppendLine($"Defence: {(this.DefenseMode == true ? "On" : "OFF")}");

            return sb.ToString().Trim();
        }
    }
}
