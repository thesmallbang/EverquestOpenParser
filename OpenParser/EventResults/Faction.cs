using OpenParser.Enums;

namespace OpenParser.EventResults
{
    public class Faction
    {
        public Faction(FactionChanges change, string group, int amount)
        {
            Change = change;
            Group = group;
            Amount = amount;
        }

        public string Group { get; }
        public int Amount { get; }

        public FactionChanges Change { get; private set; }
    }
}