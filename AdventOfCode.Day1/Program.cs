using Spectre.Console;

namespace AdventOfCode.Day1;

public class Program
{
    public static async Task Main(string[] args)
    {
        var path = AnsiConsole.Ask<string>("What is the path to the input?");

        var parser = new Parser(path);

        var highestCalories = await parser.GetHighestCaloriesAsync();

        AnsiConsole.MarkupLineInterpolated($"Highest calories: {highestCalories}");
    }

    
}