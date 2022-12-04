namespace AdventOfCode.Day4
{
    internal class CleanupSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            int totalIncludedSections = 0;

            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                (string First, string Second) assignments = GetAssignments(line);
                Section firstSection = GetSection(assignments.First);
                Section secondSection = GetSection(assignments.Second);

                if (firstSection.Contains(secondSection) || secondSection.Contains(firstSection))
                {
                    totalIncludedSections++;
                }
            }

            return totalIncludedSections.ToString();
        }

        private static (string First, string Second) GetAssignments(string pair)
        {
            string[] split = pair.Split(',');
            return (split[0], split[1]);
        }

        private static Section GetSection(string assignment)
        {
            string[] split = assignment.Split('-');
            return new Section(int.Parse(split[0]), int.Parse(split[1]));
        }
    }
}