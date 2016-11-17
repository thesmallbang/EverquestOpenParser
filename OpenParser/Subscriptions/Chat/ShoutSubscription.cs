using System.Text.RegularExpressions;
using OpenParser.EventResults.Chat;
using OpenParser.Subscriptions.Strategies;

namespace OpenParser.Subscriptions.Chat
{
    public class ShoutSubscription : Subscription<ChatMessage>
    {
        public ShoutSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(Constants.Chat.ShoutRegex, HandleMatches));
            Subscribe();
        }

        private ChatMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var message = match.Groups[4].Value;

            return new ChatMessage(entry, from, message);
        }
    }
}