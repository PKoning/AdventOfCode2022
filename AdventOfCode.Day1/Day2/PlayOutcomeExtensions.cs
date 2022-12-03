namespace AdventOfCode.Day2
{
    internal static class PlayOutcomeExtensions
    {
        internal static PlayOutcome ToPlayOutcome(this char value)
        {
            switch (value)
            {
                case 'X':
                    return PlayOutcome.Lose;
                case 'Y':
                    return PlayOutcome.Draw;
                case 'Z':
                    return PlayOutcome.Win;
                default:
                    throw new ArgumentOutOfRangeException($"{value} is not a valid play outcome");
            }
        }
    }
}