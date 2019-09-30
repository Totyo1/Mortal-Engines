using System;
using MortalEngines.IO.Contracts;

namespace MortalEngines.IO
{
    class Writer : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
