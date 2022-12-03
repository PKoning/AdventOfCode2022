namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that defines we should be able to solve a puzzle.
    /// </summary>
    internal interface IPuzzleSolver
    {
        /// <summary>
        /// Solves a puzzle.
        /// </summary>
        /// <param name="inputPath">The path of the input file.</param>
        /// <returns>The answer to the puzzle.</returns>
        internal Task<string> SolvePuzzleAsync(string inputPath);
    }
}
