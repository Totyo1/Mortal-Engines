using System;
using MortalEngines.Core;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachineManager machineManager = new MachineManager();
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                string[] data = input.Split();

                switch (data[0])
                {
                    case "HirePilot":
                        Console.WriteLine(machineManager.HirePilot(data[1]));
                        break;
                    case "PilotReport":
                        Console.WriteLine(machineManager.PilotReport(data[1]));
                        break;
                    case "ManufactureTank":
                        Console.WriteLine(machineManager.ManufactureTank(data[1], double.Parse(data[2]), double.Parse(data[3])));
                        break;
                    case "ManufactureFighter":
                        Console.WriteLine(machineManager.ManufactureFighter(data[1], double.Parse(data[2]), double.Parse(data[3])));
                        break;
                    case "MachineReport":
                        Console.WriteLine(machineManager.MachineReport(data[1]));
                        break;
                    case "AggressiveMode":
                        Console.WriteLine(machineManager.ToggleFighterAggressiveMode(data[1]));
                        break;
                    case "DefenseMode":
                        Console.WriteLine(machineManager.ToggleTankDefenseMode(data[1]));
                        break;
                    case "Engage":
                        Console.WriteLine(machineManager.EngageMachine(data[1], data[2]));
                        break;
                    case "Attack":
                        Console.WriteLine(machineManager.AttackMachines(data[1], data[2]));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}