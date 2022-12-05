namespace AdventOfCode.Day5
{
    using System.Text.RegularExpressions;

    internal class SupplyStackSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            List<string> stackInput = new();
            bool readStacks = false;

            List<List<char>>? stacks = null;

            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                // If it's an empty line, just skip
                if (string.IsNullOrWhiteSpace(line))
                {
                    // Just to be sure
                    readStacks = true;
                    continue;
                }

                if (!readStacks)
                {
                    if (line.Contains('['))
                    {
                        // This is just another line with stacks
                        stackInput.Add(line);
                    }
                    else
                    {
                        int numberOfStacks = line
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Last();
                        stacks = new List<List<char>>(numberOfStacks);
                        for (int i = 0; i < numberOfStacks; i++)
                        {
                            stacks.Add(new List<char>());
                        }

                        ReadIntoStacks(stackInput, stacks);

                        readStacks = true;
                    }
                }
                else
                {
                    (int Amount, int FromIndex, int ToIndex) move = ParseMoveInput(line);
                    var crates = stacks![move.FromIndex].Take(move.Amount);
                    stacks[move.ToIndex].InsertRange(0, crates);
                    stacks[move.FromIndex].RemoveRange(0, move.Amount);
                }
            }

            return new string(stacks!.Select(s => s.FirstOrDefault()).ToArray());
        }

        private static (int Amount, int FromIndex, int ToIndex) ParseMoveInput(string input)
        {
            MatchCollection matches = Regex.Matches(input, "\\d+");
            if (matches.Count == 3)
            {
                return (int.Parse(matches[0].Value), int.Parse(matches[1].Value) - 1, int.Parse(matches[2].Value) - 1);
            }

            throw new InvalidOperationException("Moving input does not have 3 parts");
        }

        private static void ReadIntoStacks(List<string> stackInput, List<List<char>> stacks)
        {
            int numberOfStacks = stacks.Count;
            for (int i = stackInput.Count - 1; i >= 0; i--)
            {
                string input = stackInput[i];
                for (int j = 0; j < numberOfStacks; j++)
                {
                    char crateValue = input[(j * 3) + j + 1];
                    if (crateValue != ' ')
                    {
                        stacks[j].Insert(0, crateValue);
                    }
                }
            }
        }
    }
}