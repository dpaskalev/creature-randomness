﻿using System;
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

        public Creature()
        {
            Beauty = GetRandomDiapason();
            Smarts = GetRandomDiapason();
            Phisics = GetRandomDiapason();

            arr = GetSettedArray(arr, Smarts);

            baseSpeechSkill = Beauty + Smarts;
            speechDecimal = GetSpeechDecimal(speechDecimal);
        }

        public void PrintData()
        {
            PrintMessage("Beauty", Beauty.ToString(),Utilities.Getmark(1,Beauty));
            PrintMessage("Smarts", Smarts.ToString(),Utilities.Getmark(4, Smarts));
            PrintMessage("Phisics", Phisics.ToString(),Utilities.Getmark(7, Phisics));

            Console.WriteLine();
            PrintSplitBaseData(arr);

            Console.WriteLine();
            PrintMessage("Powers");
            PrintChance(new List<string>(Utilities.GetPowers()));

            Console.WriteLine();
            PrintMessage("Skills");
            PrintChance(new List<string>(Utilities.GetSkills()));

            Console.WriteLine();
            PrintMessage("Base speech skill", $"{(baseSpeechSkill / speechDecimal):f2}");
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

        private void PrintChance(List<string> colection)
        {
            string name = "";
            string perk = "";
            int random = 0;
            int denial = 101;

            while (colection.Count > 0)
            {
                if (Utilities.GetRandom(0,101) > Utilities.GetRandom(0,denial))
                {
                    denial += 200;

                    random = Utilities.GetRandom(0, colection.Count);
                    name = colection[random];
                    colection.RemoveAt(random);

                    perk = GetChancePerk(name);

                    PrintMessage(name, perk);
                }
                else
                {
                    break;
                }
            }
        }

        private void PrintSplitBaseData(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                PrintMessage(Utilities.GetBaseSplit(i), arr[i].ToString());
            }
        }

        private int[] GetSettedArray(int[] arr,int Smarts)
        {
            int max = Smarts;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Utilities.GetRandom(0, max);

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

            int value = GetMax(max);

            arr[index1] += value;
            arr[index2] += (max - value);

            return arr;
        }

        private int GetMax(int max)
        {
            int value;

            if (max % 2 != 0)
            {
                value = max / 2 + 1;
            }
            else
            {
                value = max / 2;
            }

            return value;
        }

        private int GetSpeechDecimal(int speechDecimal)
        {
            if (Smarts > 90)
            {
                speechDecimal = 1;
            }
            else if (Smarts > 70)
            {
                speechDecimal = 2;
            }
            else if (Smarts > 30)
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
    }
}