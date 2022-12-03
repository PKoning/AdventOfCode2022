namespace AdventOfCode.Day1
{
    using Spectre.Console;

    internal sealed class CaloriePuzzleSolver : IPuzzleSolver
    {
        private List<Elf> _highestElves;
        private int _caloriesOfCurrentElf;

        public CaloriePuzzleSolver()
        {
            _highestElves = new List<Elf>(3);
        }

        async Task<string> IPuzzleSolver.SolvePuzzleAsync(string inputPath)
        {
            Initialize();

            bool hasProcessed = false;
            await foreach (string line in File.ReadLinesAsync(inputPath))
            {
                if (ParseLine(line, out int calories))
                {
                    _caloriesOfCurrentElf += calories;
                    hasProcessed = false;
                }
                else
                {
                    // We don't have anymore lines for this elf
                    ProcessElf();
                    hasProcessed = true;
                }
            }

            // Always process the last elf, we can't be sure there's another
            if (!hasProcessed)
            {
                ProcessElf();
            }

            return _highestElves.Sum(e => e.NumberOfCalories).ToString();
        }

        private void Initialize()
        {
            _highestElves = new List<Elf>(3);
            _caloriesOfCurrentElf = 0;
        }

        private void ProcessElf()
        {
            AnsiConsole.MarkupInterpolated($"Processing new elf with [grey]{_caloriesOfCurrentElf}[/] calories");
            if (_highestElves.Count < 3)
            {
                _highestElves.Add(new Elf(_caloriesOfCurrentElf));
            }
            else
            {
                Elf lowestElf = _highestElves.MinBy(e => e.NumberOfCalories)!;
                if (_caloriesOfCurrentElf > lowestElf.NumberOfCalories)
                {
                    _highestElves.Remove(lowestElf);
                    _highestElves.Add(new Elf(_caloriesOfCurrentElf));
                }
            }

            AnsiConsole.MarkupLineInterpolated(
                $" - New list: {string.Join(", ", _highestElves.Select(e => e.NumberOfCalories))}");

            // Reset the calories of the current elf
            _caloriesOfCurrentElf = 0;
        }

        private static bool ParseLine(string line, out int calories)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                calories = 0;
                return false;
            }

            calories = Convert.ToInt32(line);
            return true;
        }
    }
}