namespace OpenParser.EventResults
{
    public class Tell
    {
        public Tell(LogEntry entry, string from, string message)
        {
            LogEntry = entry;
            From = from;
            Message = message;
        }

        public string From { get; private set; }
        public string Message { get; private set; }

        public LogEntry LogEntry { get; private set; }
    }
}