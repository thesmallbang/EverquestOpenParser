using System.Text.RegularExpressions;
using OpenParser.EventResults.Chat;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers.Chat
{
    public class AuctionSubscription : Subscription<ChatMessage>
    {
        public AuctionSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(Constants.Chat.AuctionRegex, HandleMatches));
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