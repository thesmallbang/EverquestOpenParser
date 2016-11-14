using OpenParser.Constants;

namespace OpenParser.Subscribers.Strategies.Say
{
    public class SayPlayerStrategy : ISayStrategy
    {
        public bool IsMatch(LogEntry entry)
        {
            return entry.Text.IsRegexMatch(Chat.PlayerSayRegex);
        }

        public HandlerObjects.Say GetSay(LogEntry entry)
        {
            return HandlerObjects.Say.Create(HandlerObjects.Say.OriginOptions.Player, entry);
        }
    }
}