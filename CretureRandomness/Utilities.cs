using System;
using System.Collections.Generic;

namespace CretureRandomness
{
    public static class Utilities
    {
        private static readonly List<string> powers = new List<string>
        {
            "Fire",
            "Can do magic",
            "Can do magic",
            "Can do magic",
            "Ice",
            "Thunder",
            "Transmutation",
            "Has aura",
            "Has aura",
            "Has aura",
            "Hipnotisis",
            "Shadow",
            "Thoth reading",
            "Cloning",
            "Shapeshifting",
            "Alchemy",
            "Regeneration",
            "Phisical illusions",
            "Pedal Burst(Ruby)",
            "Electric overcharge",
            "I burn (Yang)",
            "MoonSlice (Adam)",
            "Alchemy",
            "Can do magic",
            "Can do magic",
            "Can do magic",
            "Portal creation",
            "Size portal",
            "Teleportation",
            "Phisics increas(All might)",
            "Multiple actions(166.)",
            "Has aura",
            "Has aura",
            "Has aura",
            "Telekinezy",
            "Can do magic",
            "Can do magic",
            "Can do magic",
            "Glyphs(shnee)",
            "Damage redirection",
            "Teleskopatic limbs",
            "Zero gravity",
            "Stone flesh",
            "Icreaed sences",
            "Fiber Master",
            "Has aura",
            "Has aura",
            "Has aura",
            "Size Changer",
            "Power Copy",
            "Shadow Cloning",
        };

        private static readonly List<string> skills = new List<string>
        {
           "Speech",
           "Marcial arts",
           "Sneak",
           "One hand",
           "Two hands",
           "Lockpick(Haking)",
           "Pickpocket",
           "Archery(weapone use)",
           "Cooking",
           "Smithing(Tech smith)",
           "Singer",
           "Doctor"
        };

        private static readonly Dictionary<string, string[]> perks = new Dictionary<string, string[]>
        {
                {"Sneak", new string[]{ "MuffleMoovement", "Invisibility", } },
                {"Lockpick(Haking)", new string[]{ "Hacker", "ElectronicSlavery", } },
                {"Pickpocket", new string[]{"AmmoThieve", "EnquipmentThieve", } },
                {"Archery(weapone use)", new string[]{ "AimBot", "DefenceIgnorence", } },
                {"Speech", new string[]{ "", "", } },
                {"Cooking", new string[]{ "GarbageTransmute", "Alchemist", } },
                {"Smithing(Tech smith)", new string[]{ "Electronics", "AlienTech", } },
                {"One hand", new string[]{ "NoWeight", "DefenceIgnorence", } },
                {"Two hands", new string[]{ "NoWeight", "DefenceIgnorence", } },
                {"Marcial arts", new string[]{"", "", } },
                {"Singer", new string[]{ "Artist", "Syrena", } },
                {"Doctor", new string[]{ "Herbivore", "Paralisis", } }
        };

        private static readonly List<string> baseData = new List<string>
        {
            "Normal",
            "Ugly",
            "Beautifull",
            "Ultimate",
            "Stupid",
            "Genious",
            "Increadible",
            "Weak",
            "Fit",
            "Strong",
            "Bad",
            "Good",
            "Master"
        };

        private static readonly List<string> wizardType = new List<string>
        {
            "Destructional",
            "Alterational",
            "Restorational",
            "Illusional",
            "Conjurational",
            "Unique"
        };

        private static readonly List<string> auraType = new List<string>
        {
            "Enhancer",
            "Emitter",
            "Transmuter",
            "Manipulator",
            "Conjurer",
            "Enspacial"
        };

        private static readonly List<string> names = new List<string>
        {
            "1.",
            "2.",
            "3.",
            "4.",
            "5.",
            "6.",
            "7.",
            "8.",
            "9.",
            "10.",
            "11.",
            "12.",
            "13.",
            "14.",
            "15.",
            "16.",
            "17.",
            "18.",
            "19.",
            "20.",
            "21.",
            "22.",
            "23.",
            "24.",
            "25.",
            "26.",
            "27.",
            "28.",
            "29.",
            "30.",
            "31.",
            "32.",
            "33.",
            "34.",
            "35.",
            "36.",
            "37.",
            "38.",
            "39.",
            "40.",
            "41.",
            "42.",
            "43.",
            "44.",
            "45.",
            "46.",
            "47.",
            "48.",
            "49.",
            "50.",
            "51.",
            "52.",
            "53.",
            "54.",
            "55.",
            "56.",
            "57.",
            "58.",
            "59.",
            "60.",
            "61.",
            "62.",
            "63.",
            "64.",
            "65.",
            "66.",
            "67.",
            "68.",
            "69.",
            "02",
            "164.",
            "176.",
            "Ala",
            "Asriel",
            "Battle Fire",
            "C.C.",
            "Drago",
            "Iris",
            "Jax",
            "Juigalag",
            "Katia",
            "Luculia",
            "Maph",
            "Metheus",
            "Mikuu",
            "Miran",
            "Oblivian",
            "Sailas",
            "Sheogoraph",
            "Yuzuki",
            "Zack",
        };

        public static List<string> GetPowers()
        {
            return powers;
        }

        public static List<string> GetSkills()
        {
            return skills;
        }

        public static List<string> GetNames()
        {
            return names;
        }

        public static string[] GetPerk(string name)
        {
            return perks[name];
        }

        public static int GetRandom(int bottom, int top)
        {
            Random random = new Random();
            return random.Next(bottom, top);
        }

        public static string GetRandomWizardType()
        {
            return wizardType[GetRandom(0, wizardType.Count)];
        }

        public static string GetRandomAuraType()
        {
            return auraType[GetRandom(0, auraType.Count)];
        }

        public static string GetDataInfo(string name, string level = "", string mark = "", string perk1 = "", string perk2 = "")
        {
            return $"{name}: {level} {mark} {perk1} {perk2}";
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

        private static bool GetIfDarkRed(string mark = "")
        {
            bool result = false;

            switch (mark)
            {
                case "Ugly":
                case "Stupid":
                case "Weak":
                case "Bad":
                case "Skills":
                case "Powers":
                case "Base":
                case "speech":
                case "skill:":
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
                case "Good":
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
                case "Master":
                case "Invisibility":
                case "ElectronicSlavery":
                case "EnquipmentThieve":
                case "DefenceIgnorence":
                case "Alchemist":
                case "AlienTech":
                case "Syrena":
                case "Paralisis":
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
                case "MuffleMoovement":
                case "Hacker":
                case "AmmoThieve":
                case "AimBot":
                case "GarbageTransmute":
                case "Electronics":
                case "NoWeight":
                case "Artist":
                case "Herbivore":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
