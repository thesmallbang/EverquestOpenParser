namespace OpenParser.EventResults.Chat
{
    public class ChatMessage
    {
        public ChatMessage(LogEntry entry, string from, string message)
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