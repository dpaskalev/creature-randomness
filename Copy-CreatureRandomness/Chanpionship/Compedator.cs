using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Chanpionship
{
    public class Compedator
    {
        public string Name { get; private set; }
        public int Wins { get; private set; } = 0;

        public Compedator(string name)
        {
            Name = name;
        }

        public void AddWin()
        {
            Wins++;
        }
    }
}
