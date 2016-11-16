namespace OpenParser.EventResults
{
    public class Tell : ChatMessage
    {
        public Tell(LogEntry entry, string from, string to, string message) : base(entry, from, message)
        {
            To = to;
        }

        public string To { get; private set; }
    }
}