using CretureRandomness.RandomName;
using System;
using System.Collections.Generic;

namespace CretureRandomness
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IGame> games = new List<IGame>();
            FillGames(games);
            
            int position = 1;

            while (true)
            {
                PrintElements(position,games);

                ConsoleKeyInfo input = Console.ReadKey();
                char result = input.KeyChar;

                Console.Clear();

                if (GetChoiceResult(result, position, games.Count) == position)
                {
                    RunGameEngine(position, games);
                }
                else
                {
                    position = GetChoiceResult(result, position, games.Count);
                }
            }
        }

        static int GetChoiceResult(char result,int position,int maxCount)
        {
            switch (result)
            {
                case 's':
                    position++;
                    break;
                case 'e':
                    return position;
                case 'w':
                    position--;
                    break;
                default:
                    PrintMasage("Wrong input - ", result);
                    break;
            }

            if (position > maxCount)
            {
                position = 1;
            }
            else if (position < 1)
            {
                position = maxCount;
            }

            return position;
        }

        static void RunGameEngine(int position,List<IGame> games)
        {
            Console.Clear();

            games[position - 1].RunEngine();

            ConsoleKeyInfo pouse = Console.ReadKey();

            Console.Clear();
        }

        static void PrintMasage(string masage,char result = ' ')
        {
            Utilities.SetColor("Powers");

            Console.WriteLine($"{masage}{result}");

            Utilities.SetColor();
        }

        static void FillGames(List<IGame> games)
        {
            CreatureRandomnessEngine creatureRandomness = new CreatureRandomnessEngine();
            RandomNameEngine randomName = new RandomNameEngine();

            games.Add(creatureRandomness);
            games.Add(randomName);
        }

        static void PrintElements(int position,List<IGame> games)
        {
            Console.WriteLine($"Items Up - {position - 1}");
            Console.WriteLine($"{games[position - 1].Name}");
            Console.WriteLine($"Items Down - {games.Count - position}");
        }
    }
}
