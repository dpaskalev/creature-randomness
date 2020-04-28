using System;
using System.Collections.Generic;

namespace CretureRandomness
{
    public class Creature
    {
        public List<Skill> skills = new List<Skill>();
        public List<string> powers = Utilities.GetPowers();
        private Skill skillModel;

        private double baseSpeechSkill = 0;

        private int speechDecimal = 4;
        private int sneakBuff = 0;
        private int oneHandBuff = 0;
        private int twoHandsBuff = 0;

        public int Beauty { get; private set; }
        public int Smarts { get; private set; }
        public int Phisics { get; private set; }

        public Creature()
        {
            Beauty = Utilities.GetRandom(0, 101);
            Smarts = Utilities.GetRandom(0, 101);
            Phisics = Utilities.GetRandom(0, 101);
            baseSpeechSkill = Beauty + Smarts;
            SetSpeechDecimal();
        }

        public void PrintCreatureData()
        {
            PrintBaseData("Beauty",1);
            PrintBaseData("Smarts",4);
            PrintBaseData("Phisics",7);
        }

        public void PrintPowers()
        {
            int random;
            int denial = 101;
            while (powers.Count > 0)
            {
                if (Utilities.GetRandom(0,101) > Utilities.GetRandom(0, denial))
                {
                    denial += 500;
                    random = Utilities.GetRandom(0, powers.Count);
                    PrintDeterminatedType(powers[random]);
                    RemoveAllEqualPowers(powers[random]);
                }
                else
                {
                    break;
                }
            }
        }

        public void PrintSkills()
        {
            foreach (Skill skill in skills)
            {
                PrintBaseData(skill.Name, 10, skill.perks[0], skill.perks[1], skill.Level);
            }
            PrintBaseSpeechSkill();
        }

        public void GenerateSkills()
        {
            List<string> skills = Utilities.GetSkills();
            int denial = 101;
            foreach (string item in skills)
            {
                if (Utilities.GetRandom(0,101) > Utilities.GetRandom(0, denial))
                {
                    denial += 100;
                    skillModel = new Skill(item, Utilities.GetRandom(0, 101));
                }
                else
                {
                    skillModel = new Skill(item, GetTop(Smarts));
                }

                DeterminateSkillDetails();

                this.skills.Add(skillModel);
            }
        }

        private int GetBotom(int smarts)
        {
            if (smarts > 90)
            {
                return Utilities.GetRandom(30, 100);
            }
            else if (smarts > 70)
            {
                return Utilities.GetRandom(20, 100);
            }
            else if (smarts > 30)
            {
                return Utilities.GetRandom(10, 100);
            }
            else
            {
                return Utilities.GetRandom(0, 100);
            }
        }

        private int GetTop(int smarts)
        {
            if (smarts > 90)
            {
                return Utilities.GetRandom(0, 101);
            }
            else if (smarts > 70)
            {
                return Utilities.GetRandom(0, 76);
            }
            else if (smarts > 30)
            {
                return Utilities.GetRandom(0, 51);
            }
            else
            {
                return Utilities.GetRandom(0, 26);
            }
        }

        private void PrintBaseData(string name,int index,string perk1 = "",string perk2 = "",int level = 0)
        {
            string[] data = Utilities.GetDataInfo(name, GetLevel(name,level).ToString(), Utilities.Getmark(index, GetLevel(name,level)),perk1,perk2).Split();
            for (int i = 0; i < data.Length; i++)
            {
                Utilities.SetColor(data[i]);
                Console.Write($"{data[i]} ");
            }
            Console.WriteLine();
            Utilities.SetColor();
        }

        private int GetLevel(string name = "",int level = 0)
        {
            int result;
            switch (name)
            {
                case "Beauty":
                    result = Beauty;
                    break;
                case "Smarts":
                    result = Smarts;
                    break;
                case "Phisics":
                    result = Phisics;
                    break;
                default:
                    result = level;
                    break;
            }
            return result;
        }

        private void DeterminateSpeechBonus(Skill skill)
        {
            if (skill.Level > 30)
            {
                int speechBuff = skill.Level;
                if (skill.Level > 90)
                {
                    if (speechDecimal > 1)
                    {
                        speechDecimal = 1;
                    }
                    else
                    {
                        speechBuff += 60;
                    }
                }
                else if (skill.Level > 70)
                {
                    if (speechDecimal > 1)
                    {
                        speechDecimal--;
                    }
                    else
                    {
                        speechBuff += 30;
                    }
                }
                baseSpeechSkill /= speechDecimal;
                baseSpeechSkill += speechBuff;
            }
            else
            {
                baseSpeechSkill /= speechDecimal;
            }
        }

        private void DeterminateMarcialArtsBonus(Skill skill)
        {
            if (skill.Level > 70)
            {
                sneakBuff += 30;
            }
            if (skill.Level > 90)
            {
                oneHandBuff += 30;
                twoHandsBuff += 30;
            }
        }

        private void DeterminateSkillDetails()
        {
            switch (skillModel.Name)
            {
                case "Speech":
                    DeterminateSpeechBonus(skillModel);
                    break;
                case "Marcial arts":
                    DeterminateMarcialArtsBonus(skillModel);
                    break;
                case "Sneak":
                    SetSneekBuff();
                    skillModel.SetLevel(skillModel.Level += sneakBuff);
                    break;
                case "One hand":
                    skillModel.SetLevel(skillModel.Level += oneHandBuff);
                    break;
                case "Two hands":
                    skillModel.SetLevel(skillModel.Level += twoHandsBuff);
                    break;
                default:
                    break;
            }
        }

        private void SetSneekBuff()
        {
            if (Phisics > 90)
            {
                sneakBuff -= 30;
                oneHandBuff += 30;
                twoHandsBuff += 30;
            }
            else if (Phisics > 70)
            {
                sneakBuff -= 15;
                oneHandBuff += 15;
                twoHandsBuff += 15;
            }
            else if (Phisics < 31)
            {
                sneakBuff += 30;
                oneHandBuff -= 30;
                twoHandsBuff -= 30;
            }
        }

        private void PrintBaseSpeechSkill()
        {
            string[] data = new string[] { "Base", "speech", "skill:" };
            for (int i = 0; i < data.Length; i++)
            {
                Utilities.SetColor(data[i]);
                Console.Write($"{data[i]} ");
            }
            Utilities.SetColor();
            Console.WriteLine($"{baseSpeechSkill:f2}");
        }

        private void SetSpeechDecimal()
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
        }

        private void RemoveAllEqualPowers(string power)
        {
            for (int i = 0; i < powers.Count; i++)
            {
                if (powers[i] == power)
                {
                    powers.RemoveAt(i);
                    i--;
                }
            }
        }

        private void PrintDeterminatedType(string power)
        {
            switch (power)
            {
                case "Can do magic":
                    Console.Write($"{power}: ");
                    Console.WriteLine(Utilities.GetRandomWizardType());
                    break;
                case "Has aura":
                    Console.Write($"{power}: ");
                    Console.WriteLine(Utilities.GetRandomAuraType());
                    break;
                default:
                    Console.WriteLine(power);
                    break;
            }
        }
    }
}
