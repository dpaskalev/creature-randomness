using System.Collections.Generic;

namespace CretureRandomness
{
    public class Skill
    {
        public string Name { get; private set; }
        public int Level { get; set; }

        public List<string> perks { get; } = new List<string>() { "", "" };

        public Skill(string name,int level)
        {
            Name = name;
            Level = level;
            DefineWorthy(Level);
        }

        public void AddPerks(string perk)
        {
            perks.Add(perk);
        }

        public void AddPerks(List<string> collection)
        {
            foreach (string item in collection)
            {
                perks.Add(item);
            }
        }

        public void SetLevel(int level)
        {
            Level = level;
            DefineWorthy(level);
        }

        private void DefineWorthy(int level)
        {
            perks[0] = "";
            perks[1] = "";

            if (level > 70)
            {
                perks[0] = Utilities.GetPerk(Name)[0]; 
            }
            if (level > 90)
            {
                perks[1] = Utilities.GetPerk(Name)[1];
            }
        }
    }
}
