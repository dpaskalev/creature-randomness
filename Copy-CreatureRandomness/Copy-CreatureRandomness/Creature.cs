using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Copy_CreatureRandomness
{
    public class Creature
    {
        public int Beauty { get; private set; }
        public int Smarts { get; private set; }
        public int Phisics { get; private set; }

        private readonly int[] arr = new int[6];
        private double baseSpeechSkill = 0;
        private int speechDecimal = 4;
        private int speechBuff = 0;
        private List<string[]> powers = new List<string[]>();
        private List<string[]> skills = new List<string[]>();

        public Creature()
        {
            Beauty = GetRandomDiapason();
            Smarts = GetRandomDiapason();
            Phisics = GetRandomDiapason();

            arr = GetSettedArray(arr, Smarts);

            baseSpeechSkill = Beauty + Smarts;

            AddChance(new List<string>(Utilities.GetPowers()), powers);
            AddChance(new List<string>(Utilities.GetSkills()), skills);

            speechDecimal = GetSpeechDecimal(speechDecimal);
            baseSpeechSkill = GetSettedBaseSpeechSkill(baseSpeechSkill, speechDecimal);
        }

        public void PrintData()
        {
            PrintMessage("Beauty", Beauty.ToString(),Utilities.Getmark(1,Beauty));
            PrintMessage("Smarts", Smarts.ToString(),Utilities.Getmark(4, Smarts));
            PrintMessage("Phisics", Phisics.ToString(),Utilities.Getmark(7, Phisics));

            PrintAllData(arr);
        }

        public void PrintMessage(string name, string level = "", string mark = "", string perk1 = "", string perk2 = "")
        {
            Utilities.SetColor(name);
            Console.Write($"{name}: ");

            Utilities.SetColor(level);
            Console.Write($"{level} ");

            Utilities.SetColor(mark);
            Console.Write($"{mark} ");

            Utilities.SetColor(perk1);
            Console.Write($"{perk1} ");

            Utilities.SetColor(perk2);
            Console.WriteLine($"{perk2}");

            Utilities.SetColor();
        }

        private int GetRandomDiapason()
        {
            int random;

            if (Utilities.GetRandom(0,101) > Utilities.GetRandom(0,301))
            {
                random = Utilities.GetRandom(0, 101);
            }
            else
            {
                random = Utilities.GetRandom(30, 91);
            }

            return random;
        }

        private void AddChance(List<string> colection,List<string[]> stats)
        {
            string name = "";
            string perk = "";
            int random = 0;
            int denial = 151;

            while (colection.Count > 0)
            {
                if (Utilities.GetRandom(0,101) > Utilities.GetRandom(0,denial))
                {
                    denial += 200;

                    random = Utilities.GetRandom(0, colection.Count);
                    name = colection[random];

                    perk = GetChancePerk(name);

                    ArrayBuffer(name, perk);

                    colection.RemoveAt(random);

                    stats.Add(new string[] {name, perk});
                }
                else
                {
                    break;
                }
            }
        }

        private void ArrayBuffer(string name = "", string perk = "")
        {
            if (name == "Martial arts")
            {
                arr[5] += 10;
                arr[3] += 10;
            }
            if (name == "Martial arts" || name == "Archery")
            {
                arr[4] += 10;
            }
            else if (name == "Speech")
            {
                arr[2] += 10;
                speechBuff += 30;
            }
            else if (name == "Smithing")
            {
                arr[0] += 10;
            }

            if (perk == "Toth reading")
            {
                arr[2] += 10;
                baseSpeechSkill += 50;
            }
            if (perk == "Paralisis" || perk == "Detect life")
            {
                arr[0] += 10;
            }
            else if (perk == "Paralisis")
            {
                arr[5] += 10;
                arr[3] += 10;
            }
            else if (perk == "Alien technology")
            {
                arr[0] += 10;
            }
        }

        private void PrintAllData(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                PrintMessage(Utilities.GetBaseSplit(i), arr[i].ToString());
            }

            Console.WriteLine();
            PrintMessage("Powers");
            for (int i = 0; i < powers.Count; i++)
            {
                PrintMessage(powers[i][0],powers[i][1]);
            }

            Console.WriteLine();
            PrintMessage("Skills");
            for (int i = 0; i < skills.Count; i++)
            {
                PrintMessage(skills[i][0], skills[i][1]);
            }

            Console.WriteLine();
            PrintMessage("Base speech skill", $"{baseSpeechSkill:f2}");
        }

        private int[] GetSettedArray(int[] arr,int Smarts)
        {
            int max = Smarts;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Utilities.GetRandom(0, max / 2);

                max -= arr[i];

                if (i == (arr.Length / 2) - 1 || i == arr.Length - 1)
                {
                    if (max > 0)
                    {
                        arr = GetSettedMax(arr, i, max);
                    }

                    max = Phisics;
                }
            }

            return arr;
        }

        private int[] GetSettedMax(int[]arr, int i, int max)
        {
            int bottom = i - 2;
            int index1;
            int index2;

            while (true)
            {
                index1 = Utilities.GetRandom(bottom, i + 1);
                index2 = Utilities.GetRandom(bottom, i + 1);
                if (index2 != index1)
                {
                    break;
                }
            }

            int value = max / 2;

            arr[index1] += value;
            arr[index2] += (max - value);

            return arr;
        }

        private int GetSpeechDecimal(int speechDecimal)
        {
            if (arr[2] > 49)
            {
                speechDecimal = 1;
            }
            else if (arr[2] > 44)
            {
                speechDecimal = 2;
            }
            else if (arr[2] > 19)
            {
                speechDecimal = 3;
            }

            return speechDecimal;
        }

        private string GetChancePerk(string name)
        {
            string type = "";
            int bottom = 0;
            int top = 0;

            switch (name)
            {
                case "Magic":
                    bottom = 6;
                    top = 12;
                    break;
                case "Aura":
                    top = 6;
                    break;
                default:
                    if (Utilities.GetRandom(0, 101) > Utilities.GetRandom(0, 201))
                    {
                        type = Utilities.GetPerk(name);
                    }
                    break;
            }

            if (top != 0)
            {
                type = Utilities.GetTypes()[Utilities.GetRandom(bottom, top)];
            }

            return type;
        }

        private double GetSettedBaseSpeechSkill(double baseSpeechSkill, int speechDecimal)
        {
            return (baseSpeechSkill / speechDecimal) + speechBuff;
        }
    }
}
