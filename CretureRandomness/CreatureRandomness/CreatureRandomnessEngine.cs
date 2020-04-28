using System;

namespace CretureRandomness
{
    public class CreatureRandomnessEngine : IGame
    {
        private Creature creature;

        public string Name { get; private set; } = "Creature randomness";

        public CreatureRandomnessEngine()
        {

        }

        public void RunEngine()
        {
            creature = new Creature();

            string title; 

            creature.PrintCreatureData();

            title = "Powers";

            Utilities.SetColor(title);
            Console.WriteLine(Utilities.GetDataInfo(title));
            Utilities.SetColor();

            creature.PrintPowers();

            Console.WriteLine();

            title = "Skills";

            Utilities.SetColor(title);
            Console.WriteLine(Utilities.GetDataInfo(title));

            creature.GenerateSkills();
            creature.PrintSkills();

            Utilities.SetColor();
        }
    }
}
