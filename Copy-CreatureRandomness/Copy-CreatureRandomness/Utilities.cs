using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Copy_CreatureRandomness
{
    public static class Utilities
    {
        private static readonly List<string> baseData = new List<string>
        {
            /*0*/"Normal",
            /*1*/"Ugly",
                 "Beautifull",
                 "Ultimate",
            /*4*/"Stupid",
                 "Genious",
                 "Increadible",
            /*7*/"Weak",
                 "Fit",
                 "Strong",
            /*10*/"Bad",
                 "Good",
                 "Master"
        };

        private static readonly List<string> baseDataSplit = new List<string>
        {
            "Observation",
            "Memory span",
            "Study speed",
            "Reflexes",
            "Speed",
            "Strenght",
        };

        private static readonly List<string> skills = new List<string>
        {
            "Sneak",
            "Smithing",
            "Marcial arts",
            "Chain sythe",
            "War hammer",
            "Mase",
            "Sword",
            "Great sword",
            "Battle axe",
            "War Axe",
            "Two edged sword",
            "Staff",
            "Spear",
            "Archery",
            "Speech",
        };

        private static readonly List<string> powers = new List<string>
        {
            "Regeneration",
            "Fire bending",
            "Water bending",
            "Earth bending",
            "Air bending",
            "Aura",
            "Magic",
            "Pedal burs",
            "Shadow cloning",
            "Cloning",
            "Shapeshifting",
            "Alchemy",
            "Portals",
            "Power copy",
            "Hipnosa",
        };

        private static readonly Dictionary<string, string> perks = new Dictionary<string, string>
        {
            { "Sneak","Invisibility"},
            { "Smithing","Alien technology"},
            { "Marcial arts","Paralisis"},
            { "Chain sythe","Flash"},
            { "War hammer","I burn"},
            { "Mase","Beserker's rage"},
            { "Sword","Moon slice"},
            { "Great sword","Block break"},
            { "Battle axe","Bleeding"},
            { "War Axe","Lifesteal"},
            { "Two edged sword","Damage return"},
            { "Staff","Stun"},
            { "Spear","Overhit"},
            { "Archery","Detect life"},
            { "Speech","Toth reading"},
            //
            { "Regeneration","Stamina recovery"},
            { "Fire bending","Explosions"},
            { "Water bending","Blood bending"},
            { "Earth bending","Lava bending"},
            { "Air bending","Become enterial"},
            { "Aura",""},
            { "Magic",""},
            { "Pedal burs","Teleportation"},
            { "Shadow cloning","Army"},
            { "Cloning","Clone other"},
            { "Shapeshifting","Pernament"},
            { "Alchemy","Transmutation"},
            { "Portals","Size changeing"},
            { "Power copy","Skill thieve"},
            { "Hipnosa","Comand"},
        };

        private static readonly List<string> types = new List<string>
        {
            "Enhancer",
            "Transmuter",
            "Emiter",
            "Manipulator",
            "Conjurer",
            "Enspecialist",
            "Destructional",
            "Alterational",
            "Restorational",
            "Conjurational",
            "Illusional",
            "Unique",
        };

        public static int GetRandom(int bottom, int top)
        {
            Random random = new Random();
            return random.Next(bottom, top);
        }
        
        public static string Getmark(int index, int level)
        {
            string result = baseData[0];

            if (level > 90)
            {
                result = baseData[index + 2];
            }
            else if (level > 70)
            {
                result = baseData[index + 1];
            }
            else if (level < 31)
            {
                result = baseData[index];
            }

            return result;
        }

        public static string GetBaseSplit(int index)
        {
            return baseDataSplit[index];
        }

        public static List<string> GetSkills()
        {
            return skills;
        }

        public static List<string> GetPowers()
        {
            return powers;
        }

        public static string GetPerk(string name)
        {
            return perks[name];
        }

        public static List<string> GetTypes()
        {
            return types;
        }

        public static void SetColor(string mark = "")
        {
            if (GetIfDarkRed(mark))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (GetIfDarkGreed(mark))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (GetIfDarkPurple(mark))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (GetIfYellow(mark))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        private static bool GetIfDarkRed(string mark = "")
        {
            bool result = false;

            switch (mark)
            {
                case "Ugly":
                case "Stupid":
                case "Weak":
                case "Skills":
                case "Powers":
                case "Base speech skill":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        private static bool GetIfDarkGreed(string mark = "")
        {
            bool result = false;

            switch (mark)
            {
                case "Beautifull":
                case "Genious":
                case "Fit":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        private static bool GetIfDarkPurple(string mark = "")
        {
            bool result = false;

            switch (mark)
            {
                case "Ultimate":
                case "Increadible":
                case "Strong":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        private static bool GetIfYellow(string mark = "")
        {
            bool result = false;

            switch (mark)
            {
                case "Normal":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
