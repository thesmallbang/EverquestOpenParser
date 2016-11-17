using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.EventResults.Chat;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class GuildChatSubscription : Subscription<ChatMessage>
    {
        public GuildChatSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(Chat.GuildRegex, HandleMatches));
            Subscribe();
        }

        private ChatMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var message = match.Groups[5].Value;

            return new ChatMessage(entry, from, message);
        }
    }
}