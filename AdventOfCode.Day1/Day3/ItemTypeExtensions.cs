namespace AdventOfCode.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class ItemTypeExtensions
    {
        internal static int ToItemTypePriority(this char itemType)
        {
            var charValue = (int)itemType;
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
