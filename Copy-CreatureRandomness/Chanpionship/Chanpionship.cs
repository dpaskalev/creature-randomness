using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness.Chanpionship
{
    public class Chanpionship
    {
        private List<Compedator> compedators = new List<Compedator>();
        private List<Compedator> discloified = new List<Compedator>();

        public Chanpionship()
        {
            GenerateCompedators();
        }

        private void GenerateCompedators()
        {
            foreach (string name in Utilities.GetNames())
            {
                compedators.Add(new Compedator(name));
            }
        }

        private void RunRound()
        {
            int random1;
            int random2;

            for (int i = 0; i < compedators.Count - 1; i++)
            {
                random1 = Utilities.GetRandom(0, compedators.Count);
                random2 = Utilities.GetRandom(0, compedators.Count);

                PrintMessage($"{compedators[random1].Name} vs {compedators[random2].Name}");
                PrintMessage($"Choose [1] for the first, [2] for the seccond");

                if (GetChoice() == 1)
                {
                    compedators[random1].AddWin();
                    discloified.Add(compedators[random2]);
                    compedators.RemoveAt(random2);
                }
                else if(GetChoice() == 2)
                {
                    compedators[random2].AddWin();
                    discloified.Add(compedators[random1]);
                    compedators.RemoveAt(random1);
                }
            }
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        private int GetChoice()
        {
            while (true)
            {
                char input = Console.ReadKey().KeyChar;

                bool check = int.TryParse(input.ToString(), out int result);

                if (check)
                {
                    return result;
                }
                else
                {
                    PrintMessage($"You entered wrong input [{input}], number required!");
                }
            }
        }

        private void DesquolifyCompedator()
        {

        }
    }
}
