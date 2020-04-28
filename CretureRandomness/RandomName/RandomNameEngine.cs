using System;
using System.Collections.Generic;
using System.Text;

namespace CretureRandomness.RandomName
{
    public class RandomNameEngine : IGame
    {
        public string Name { get; private set; } = "Random name";

        private readonly Names participants = new Names();

        public RandomNameEngine()
        {

        }

        public void RunEngine()
        {
            while (participants.competitors.Count > 0)
            {
                participants.PrintRound();
            }

            participants.PrintStatistics();
        }
    }
}
