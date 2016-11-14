using OpenParser.Constants;

namespace OpenParser.Subscribers.Strategies.Say
{
    public class SayAllStrategy : ISayStrategy
    {
        public bool IsMatch(LogEntry entry)
        {
            return entry.Text.IsRegexMatch(Chat.PlayerSayRegex) || entry.Text.IsRegexMatch(Chat.NpcSayRegex);
        }

        public HandlerObjects.Say GetSay(LogEntry entry)
        {
            return HandlerObjects.Say.Create(HandlerObjects.Say.GetOrigin(entry), entry);
        }
    }
}