using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Chanpionship 
{
    public class ChanpionshipEngine : IEngine
    {
        private Chanpionship chanpionship;

        public string Name { get; private set; }

        public ChanpionshipEngine(string name)
        {
            Name = name;
        }

        public void RunEngine()
        {
            chanpionship = new Chanpionship();

            chanpionship.RunResultsLoop();
        }
    }
}
