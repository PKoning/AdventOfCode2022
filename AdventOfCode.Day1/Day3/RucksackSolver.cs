namespace AdventOfCode.Day3
{
    internal class RucksackSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            int totalPriorities = 0;
            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                IEnumerable<char> sameItemTypes = GetSameItemTypes(line);
                totalPriorities += sameItemTypes.Sum(itemType => itemType.ToItemTypePriority());
            }

            return totalPriorities.ToString();
        }

        private static IEnumerable<char> GetSameItemTypes(string rucksack)
        {
            int halfMark = rucksack.Length / 2;
            string firstPart = rucksack[..halfMark];
            string lastPart = rucksack[halfMark..];

            return firstPart.ToCharArray().Intersect(lastPart.ToCharArray()).ToList();
        }
    }
}