using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Chanpionship
{
    public static class Utilities
    {
        private static readonly List<string> names = new List<string>
        {
            "",
        };

        public static List<string> GetNames()
        {
            return names;

        }

        public static int GetRandom(int bottom, int top)
        {
            Random random = new Random();
            return random.Next(bottom, top);
        }
    }
}
