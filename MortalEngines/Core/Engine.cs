using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core.Contracts
{
    class Engine : IEngine
    {
        public void Run()
        {
            PilotRepository pilotRepository = new PilotRepository();
        }
    }
}
