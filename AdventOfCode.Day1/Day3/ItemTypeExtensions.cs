namespace AdventOfCode.Day3
{
    internal static class ItemTypeExtensions
    {
        internal static int ToItemTypePriority(this char itemType)
        {
            int charValue = (int)itemType;
            if (charValue is >= 97 and <= 122)
            {
                return charValue - 96;
            }

            if (charValue is >= 65 and <= 90)
            {
                return charValue - 64 + 26;
            }

            throw new ArgumentOutOfRangeException($"Item type {itemType} is out of range for a priority");
        }
    }
}