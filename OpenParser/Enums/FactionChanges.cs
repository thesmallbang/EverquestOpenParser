using System;

namespace OpenParser.Enums
{
    [Flags]
    public enum FactionChanges
    {
        Unknown = 0,
        Increase = 1,
        Decrease = 2,
        MaxPositive = 3,
        MaxNegative = 4
    }
}