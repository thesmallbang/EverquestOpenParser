using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class OocSubscription : Subscription<ChatMessage>
    {
        public OocSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(Chat.OocRegex, HandleMatches));
            Subscribe();
        }

        private ChatMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var message = match.Groups[3].Value;

            return new ChatMessage(entry, from, message);
        }
    }
}