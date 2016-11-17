using OpenParser.Enums;

namespace OpenParser.EventResults.Chat
{
    public class Say : ChatMessage
    {
        public Say(LogEntry entry, SayOrigins origin, string from, string message) : base(entry, from, message)
        {
            Origin = origin;
        }

        public SayOrigins Origin { get; }
    }
}