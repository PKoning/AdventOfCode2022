namespace AdventOfCode.Day3
{
    internal class RucksackSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            int totalPriorities = 0;

            var index = 0;
            IEnumerable<char> intersect = Array.Empty<char>();
            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                var itemTypes = line.ToCharArray();
                if (index % 3 == 0)
                {
                    totalPriorities += intersect.Sum(itemType => itemType.ToItemTypePriority());

                    intersect = itemTypes;
                }
                else
                {
                    intersect = intersect.Intersect(itemTypes);
                }

                index++;
            }

            totalPriorities += intersect.Sum(itemType => itemType.ToItemTypePriority());

            return totalPriorities.ToString();
        }
    }
}