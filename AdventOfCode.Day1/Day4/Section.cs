namespace AdventOfCode.Day4
{
    internal class Section
    {
        public int Start { get; }
        public int End { get; }

        internal Section(int start, int end)
        {
            Start = start;
            End = end;
        }

        internal bool Contains(Section other)
        {
            return Start <= other.Start && End >= other.End;
        }
    }
}