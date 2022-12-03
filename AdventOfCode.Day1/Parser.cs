using Spectre.Console;

namespace AdventOfCode.Day1
{
    internal sealed class Parser
    {
        private List<Elf> _highestElves;
        private readonly string _path;
        private int _caloriesOfCurrentElf;

        public Parser(string path)
        {
            _path = path;
            _highestElves = new List<Elf>(3);
        }

        internal async Task<int> GetHighestCaloriesAsync()
        {
            Initialize();

            var hasProcessed = false;
            await foreach (var line in File.ReadLinesAsync(_path))
            {
                if (ParseLine(line, out var calories))
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

            return _highestElves.Sum(e => e.NumberOfCalories);
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
                var lowestElf = _highestElves.MinBy(e => e.NumberOfCalories)!;
                if (_caloriesOfCurrentElf > lowestElf.NumberOfCalories)
                {
                    _highestElves.Remove(lowestElf);
                    _highestElves.Add(new Elf(_caloriesOfCurrentElf));
                }
            }

            AnsiConsole.MarkupLineInterpolated($" - New list: {string.Join(", ", _highestElves.Select(e => e.NumberOfCalories))}");

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