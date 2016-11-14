using System;

namespace OpenParser.Enums
{
    [Flags]
    public enum DamageTypes
    {
        Unknown = 0,
        Physical = 1,
        Elemental = 2,
        Raw = 3
    }
}