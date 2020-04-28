using System;
using System.Collections.Generic;
using System.Text;

namespace CretureRandomness.RandomName
{
    public class Names
    {
        public readonly List<Competitor> competitors = new List<Competitor>();
        private readonly List<Competitor> nextElimination = new List<Competitor>();
        private readonly List<Competitor> statistics = new List<Competitor>();
        private readonly int looserIndex = 0;

        public Names()
        {
            GenerateCompetitors();
        }

        public void PrintRound()
        {
            while (competitors.Count > 1)
            {
                Console.Clear();
                Console.WriteLine($"Fight count: {competitors.Count - 2}");
                Console.WriteLine($"{competitors[looserIndex].Name} Vs {competitors[looserIndex + 1].Name}");
                Console.WriteLine(Utilities.GetDataInfo("Plese enter a winner index: [1]-first one, [2]-second one!"));

                if (GetWinnerIndex() == 1)
                {
                    competitors[looserIndex].AddWin();
                    nextElimination.Add(competitors[looserIndex]);
                    competitors.RemoveAt(looserIndex);
                }
                else
                {
                    competitors[looserIndex + 1].AddWin();
                    nextElimination.Add(competitors[looserIndex + 1]);
                    competitors.RemoveAt(looserIndex + 1);
                }
            }

            ResetFunctions();
        }

        public void PrintStatistics()
        {
            Console.Clear();

            for (int i = statistics.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"{statistics.Count - i}: {statistics[i].Name} - {statistics[i].Wins} Wins!");
                Console.WriteLine();
            }
        }

        private int GetWinnerIndex()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (GetCheckedIndex(input))
                {
                    return int.Parse(input);
                }
            }
        }

        private bool GetCheckedIndex(string input)
        {
            bool result = false;

            switch (input)
            {
                case "1":
                case "2":
                    result = true;
                    break;
                default:
                    Console.WriteLine($"Wrong input - {input}");
                    break;
            }

            return result;
        }

        private void GenerateCompetitors()
        {
            List<string> names = Utilities.GetNames();
            int random;

            while (names.Count > 0)
            {
                random = Utilities.GetRandom(0, names.Count);
                competitors.Add(new Competitor(names[random]));
                names.RemoveAt(random);
            }
        }

        private void FillCompetitorsWithElementsFromElimination()
        {
            int random;

            while (nextElimination.Count > 0)
            {
                random = Utilities.GetRandom(0, nextElimination.Count);

                competitors.Add(nextElimination[random]);
                nextElimination.RemoveAt(random);
            }
        }

        private void ResetFunctions()
        {
            PrintDescuolified();

            statistics.Add(competitors[looserIndex]);
            competitors.RemoveAt(looserIndex);

            int random;
            while (nextElimination.Count > 0)
            {
                random = Utilities.GetRandom(0, nextElimination.Count);

                competitors.Add(nextElimination[random]);

                nextElimination.RemoveAt(random);
            }
        }

        private void PrintDescuolified()
        {
            Console.Clear();

            Console.WriteLine(competitors[looserIndex].Name);

            ConsoleKeyInfo pause = Console.ReadKey();
        }
    }
}
