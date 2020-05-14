using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Copy_CreatureRandomness
{
    public class CreatureRandomnessEngine : IEngine
    {
        public string Name { get; private set; }

        private Creature creature;

        public CreatureRandomnessEngine(string name)
        {
            Name = name;
        }

        public void RunEngine()
        {
            creature = new Creature();

            creature.PrintData();
        }
    }
}
