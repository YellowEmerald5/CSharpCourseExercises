

namespace DiceRollGame
{
    internal class Dice
    {
        public long Roll { get; init; }
        private int NumberOfSides { get; init; }
        public Dice(int amountOfSides) {
            NumberOfSides = amountOfSides;
            Random r = new();
            Roll = r.NextInt64(1,NumberOfSides+1);
        }
    }
}
