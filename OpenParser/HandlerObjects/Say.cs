using OpenParser.Enums;

namespace OpenParser.HandlerObjects
{
    public class Say
    {
        public Say(LogEntry entry, SayOrigins origin, string from, string message)
        {
            Origin = origin;
            LogEntry = entry;
            From = from;
            Message = message;
        }

        public SayOrigins Origin { get; }
        public string From { get; }
        public string Message { get; }

        public LogEntry LogEntry { get; }
    }
}