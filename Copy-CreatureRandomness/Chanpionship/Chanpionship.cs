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

        public void RunResultsLoop()
        {
            LoopRound();

            PrintStatiscis(discloified);
        }

        private void GenerateCompedators()
        {
            foreach (string name in Utilities.GetNames())
            {
                compedators.Add(new Compedator(name));
            }
        }

        private void LoopRound()
        {
            int random1;
            int random2;

            while (compedators.Count > 1)
            {
                random1 = Utilities.GetRandom(0, compedators.Count);
                random2 = Utilities.GetRandom(0, compedators.Count);

                if (random1 != random2)
                {
                    PrintMessage($"{compedators[random1].Name} vs {compedators[random2].Name}");
                    PrintMessage($"Choose [1] for the first, [2] for the seccond");
                    PrintMessage($"Count: {compedators.Count}");

                    int choice = GetChoice();

                    if (choice == 1)
                    {
                        compedators[random1].AddWin();
                        discloified.Add(compedators[random2]);
                        compedators.RemoveAt(random2);
                    }
                    else if (choice == 2)
                    {
                        compedators[random2].AddWin();
                        discloified.Add(compedators[random1]);
                        compedators.RemoveAt(random1);
                    }
                    else
                    {
                        PrintMessage("Choose only between 1 & 2 !");
                    }
                }

                Console.Clear();
            }

            discloified.Add(compedators[0]);
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void PrintStatiscis(List<Compedator> disquolified)
        {
            for (int i = discloified.Count - 1; i >= 0; i--)
            {
                PrintMessage($"[{(discloified.Count - i)}] - {discloified[i].Name}: {discloified[i].Wins}");
            }
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
    }
}
