using OpenParser.Enums;

namespace OpenParser.EventResults
{
    public class Faction : EventResult
    {
        public Faction(LogEntry entry, FactionChanges change, string group, int amount) : base(entry)
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