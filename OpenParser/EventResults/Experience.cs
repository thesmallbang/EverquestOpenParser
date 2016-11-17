namespace OpenParser.EventResults
{
    public class Experience : EventResult
    {
        public Experience(LogEntry entry, bool inParty) : base(entry)
        {
            Party = inParty;
        }

        public bool Party { get; }
    }
}