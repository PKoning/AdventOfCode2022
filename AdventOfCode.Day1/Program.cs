namespace AdventOfCode;

using Day1;
using Day2;
using Day3;
using Day4;
using Day5;
using Spectre.Console;

public class Program
{
    public static async Task Main(string[] args)
    {
        string path = AnsiConsole.Ask<string>("What is the path to the input?");

        var day = AnsiConsole.Prompt(
            new SelectionPrompt<int>()
                .AddChoices(Enumerable.Range(1, 5))
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
            case 3:
                return new RucksackSolver();
            case 4:
                return new CleanupSolver();
            case 5:
                return new SupplyStackSolver();
            default:
                throw new NotImplementedException("This day has not been implemented yet");
        }
    }
}