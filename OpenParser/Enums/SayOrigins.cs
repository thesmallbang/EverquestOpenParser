using System;

namespace OpenParser.Enums
{
    [Flags]
    public enum SayOrigins
    {
        Unknown = 0,
        Player = 1,
        Npc = 2
    }
}