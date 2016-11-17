namespace OpenParser.EventResults
{
    public class Empty : EventResult
    {
        private Empty(LogEntry entry) : base(entry)
        {
        }

        public static Empty Instance(LogEntry entry) => new Empty(entry);
    }
}