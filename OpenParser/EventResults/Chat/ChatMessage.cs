namespace OpenParser.EventResults.Chat
{
    public class ChatMessage : EventResult
    {
        public ChatMessage(LogEntry entry, string from, string message) : base(entry)
        {
            From = from;
            Message = message;
        }

        public string From { get; private set; }
        public string Message { get; private set; }
    }
}