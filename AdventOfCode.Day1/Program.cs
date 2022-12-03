namespace AdventOfCode;

using Day1;
using Day2;
using Spectre.Console;

public class Program
{
    public static async Task Main(string[] args)
    {
        string path = AnsiConsole.Ask<string>("What is the path to the input?");

        var day = AnsiConsole.Prompt(
            new SelectionPrompt<int>()
                .AddChoices(Enumerable.Range(1, 2))
                .Title("Day")
                .MoreChoicesText("More days available down below")
        );

        var puzzleSolver = CreatePuzzleSolver(day);
        var answer = await puzzleSolver.SolvePuzzleAsync(path);

        AnsiConsole.MarkupLineInterpolated($"Answer to the puzzle of day {day}: {answer}");
    }

    private static IPuzzleSolver CreatePuzzleSolver(int day)
    {
        switch (day)
        {
            case 1:
                return new CaloriePuzzleSolver();
            case 2:
                return new RockPaperScissorsSolver();
            default:
                throw new NotImplementedException("This day has not been implemented yet");
        }
    }
}