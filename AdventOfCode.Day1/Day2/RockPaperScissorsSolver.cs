namespace AdventOfCode.Day2
{
    internal class RockPaperScissorsSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            int totalScore = 0;
            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                RockPaperScissorsType opponent = line[0].ToRockPaperScissorsType();
                RockPaperScissorsType player = line[2].ToRockPaperScissorsType();
                int score = DetermineScore(player, opponent);
                totalScore += score;
                totalScore += (int)player;
            }

            return totalScore.ToString();
        }

        /// <summary>
        /// Determine the score between two 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="opponent"></param>
        /// <returns></returns>
        private int DetermineScore(RockPaperScissorsType player, RockPaperScissorsType opponent)
        {
            // It's a draw
            if (player == opponent)
            {
                return 3;
            }

            // Player wins
            if ((player == RockPaperScissorsType.Rock && opponent == RockPaperScissorsType.Scissors) ||
                (player == RockPaperScissorsType.Scissors && opponent == RockPaperScissorsType.Paper) ||
                (player == RockPaperScissorsType.Paper && opponent == RockPaperScissorsType.Rock))
            {
                return 6;
            }

            return 0;
        }
    }
}