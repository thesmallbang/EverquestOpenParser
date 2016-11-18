using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class LevelSubscription : Subscription<EventResult<byte>>
    {
        public LevelSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<EventResult<byte>>(logFile,
                new RegexStrategy<EventResult<byte>>(CompiledRegex.LevelRegex, HandleMatches));
            Subscribe();
        }

        private EventResult<byte> HandleMatches(LogEntry entry, Match match)
        {
            byte level;
            byte.TryParse(match.Groups[1].Value, out level);

            return new EventResult<byte>(entry, level);
        }
    }
}