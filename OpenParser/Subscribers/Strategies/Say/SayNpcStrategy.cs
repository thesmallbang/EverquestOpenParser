using OpenParser.Constants;

namespace OpenParser.Subscribers.Strategies.Say
{
    public class SayNpcStrategy : ISayStrategy
    {
        public bool IsMatch(LogEntry entry)
        {
            return entry.Text.IsRegexMatch(Chat.NpcSayRegex) && !entry.Text.IsRegexMatch(Chat.PlayerSayRegex);
        }

        public HandlerObjects.Say GetSay(LogEntry entry)
        {
            return HandlerObjects.Say.Create(HandlerObjects.Say.OriginOptions.Npc, entry);
        }
    }
}