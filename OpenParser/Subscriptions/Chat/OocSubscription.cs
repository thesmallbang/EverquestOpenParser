using System.Text.RegularExpressions;
using OpenParser.EventResults.Chat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Chat
{
    public class OocSubscription : Subscription<ChatMessage>
    {
        public OocSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(CompiledRegex.OocRegex, HandleMatches));
            Subscribe();
        }

        private ChatMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var message = match.Groups[4].Value;

            return new ChatMessage(entry, from, message);
        }
    }
}