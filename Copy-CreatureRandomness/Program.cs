using System;
using System.Collections.Generic;
using Copy_CreatureRandomness.Copy_CreatureRandomness;
using Copy_CreatureRandomness.Chanpionship;

namespace Copy_CreatureRandomness
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEngine> games;

            int position = 1;

            while (true)
            {
                games = new List<IEngine>(GetGames());

                PrintElements(position, games);

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

        static List<IEngine> GetGames()
        {
            List<IEngine> gameList = new List<IEngine>
            {
                new CreatureRandomnessEngine("CreatureRandomness"),

                new ChanpionshipEngine("Championship"),
            };

            return gameList;
        }

        static void PrintElements(int position, List<IEngine> games)
        {
            Console.WriteLine($"Items Up - {position - 1}");
            Console.WriteLine($"{games[position - 1].Name}");
            Console.WriteLine($"Items Down - {games.Count - position}");
            Console.WriteLine(new Random().Next(1,178));
        }

        static int GetChoiceResult(char result, int position, int maxCount)
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

        static void PrintMasage(string masage, char result = ' ')
        {
            Console.WriteLine($"{masage}{result}");
        }

        static void RunGameEngine(int position, List<IEngine> games)
        {
            Console.Clear();

            games[position - 1].RunEngine();

            ConsoleKeyInfo pouse = Console.ReadKey();

            Console.Clear();
        }
    }
}
