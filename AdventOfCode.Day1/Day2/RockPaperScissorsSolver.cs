namespace AdventOfCode.Day2
{
    internal class RockPaperScissorsSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            int totalScore = 0;
            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                var opponent = line[0].ToRockPaperScissorsType();
                var outcome = line[2].ToPlayOutcome();
                totalScore += (int)outcome;

                var player = DetermineHand(opponent, outcome);
                totalScore += (int)player;
            }

            return totalScore.ToString();
        }

        private static RockPaperScissorsType DetermineHand(RockPaperScissorsType opponent, PlayOutcome outcome)
        {
            if (outcome == PlayOutcome.Draw)
            {
                return opponent;
            }

            var playerWins = outcome == PlayOutcome.Win;

            switch (opponent)
            {
                case RockPaperScissorsType.Paper:
                    return playerWins ? RockPaperScissorsType.Scissors : RockPaperScissorsType.Rock;
                case RockPaperScissorsType.Scissors:
                    return playerWins ? RockPaperScissorsType.Rock : RockPaperScissorsType.Paper;
                case RockPaperScissorsType.Rock:
                    return playerWins ? RockPaperScissorsType.Paper : RockPaperScissorsType.Scissors;
                default:
                    throw new ArgumentOutOfRangeException($"{opponent} is not a valid type");
            }
        }
    }
}