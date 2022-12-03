namespace AdventOfCode.Day2
{
    internal static class RockPaperScissorsTypeExtensions
    {
        internal static RockPaperScissorsType ToRockPaperScissorsType(this char value)
        {
            switch (value)
            {
                case 'A':
                case 'X':
                    return RockPaperScissorsType.Rock;
                case 'B':
                case 'Y':
                    return RockPaperScissorsType.Paper;
                case 'C':
                case 'Z':
                    return RockPaperScissorsType.Scissors;
                default:
                    throw new ArgumentException($"{value} is not a valid argument for Rock-Paper-Scissors");
            }
        }
    }
}