using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Chanpionship 
{
    public class ChanpionshipEngine : IEngine
    {
        public string Name { get; private set; }

        public ChanpionshipEngine(string name)
        {
            Name = name;
        }

        public void RunEngine()
        {

        }
    }
}
