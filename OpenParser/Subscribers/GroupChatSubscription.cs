using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.EventResults.Chat;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class GroupChatSubscription : Subscription<ChatMessage>
    {
        public GroupChatSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(Chat.GroupRegex, HandleMatches));
            Subscribe();
        }

        private ChatMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var message = match.Groups[6].Value;

            return new ChatMessage(entry, from, message);
        }
    }
}