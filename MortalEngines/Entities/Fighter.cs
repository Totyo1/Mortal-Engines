using System;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine , IFighter
    {
        private const double ATTACK = 50.0;
        private const double DEFENCE = 25.0;
        private const double initialHP = 200.0;
        private bool AggressiveMode;
        
        public Fighter(string name, double attackPoints, double defencePoints)
            : base(name, attackPoints, defencePoints, initialHP)
        {
            this.ToggleAggressiveMode();
        }
        bool IFighter.AggressiveMode => throw new NotImplementedException();

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                AggressiveMode = false;
                this.AttackPoints += ATTACK;
                this.DefensePoints -= DEFENCE;
            }
            else
            {
                AggressiveMode = true;
                this.AttackPoints -= ATTACK;
                this.DefensePoints += DEFENCE;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine();
            sb.AppendLine($"Aggressive: {(this.AggressiveMode == true ? "On" : "OFF")}");

            return sb.ToString().Trim();
        }
    }
}