using System;
using System.Collections.Generic;
using System.Text;

namespace CretureRandomness.RandomName
{
    public class Competitor
    {
        public string Name { get; private set; }

        public int Wins { get; private set; } = 0;

        public Competitor(string name)
        {
            Name = name;
        }

        public void AddWin()
        {
            Wins++;
        }
    }
}
