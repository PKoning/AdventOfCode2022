namespace AdventOfCode.Day5
{
    using System.Text.RegularExpressions;

    internal class SupplyStackSolver : IPuzzleSolver
    {
        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            List<string> stackInput = new List<string>();
            bool readStacks = false;

            List<Stack<char>>? stacks = null;

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
                        stacks = new List<Stack<char>>(numberOfStacks);
                        for (int i = 0; i < numberOfStacks; i++)
                        {
                            stacks.Add(new Stack<char>());
                        }

                        ReadIntoStacks(stackInput, stacks);

                        readStacks = true;
                    }
                }
                else
                {
                    (int Amount, int FromIndex, int ToIndex) move = ParseMoveInput(line);
                    for (int i = 0; i < move.Amount; i++)
                    {
                        if (stacks![move.FromIndex].TryPop(out var crate))
                        {
                            stacks[move.ToIndex].Push(crate);
                        }
                    }
                }
            }

            var stackCount = stacks!.Count;
            var answer = new List<char>(stackCount);
            for (int i = 0; i < stackCount; i++)
            {
                if (stacks[i].TryPop(out var crate))
                {
                    answer.Add(crate);
                }
            }

            return new string(answer.ToArray());
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

        private static void ReadIntoStacks(List<string> stackInput, List<Stack<char>> stacks)
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
                        stacks[j].Push(crateValue);
                    }
                }
            }
        }
    }
}