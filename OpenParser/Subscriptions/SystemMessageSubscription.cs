using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class SystemMessageSubscription : Subscription<EventResult<string>>
    {
        public SystemMessageSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<EventResult<string>>(logFile,
                new RegexStrategy<EventResult<string>>(CompiledRegex.SystemMessageRegex, HandleMatches));
            Subscribe();
        }

        private EventResult<string> HandleMatches(LogEntry entry, Match match)
            => new EventResult<string>(entry, match.Groups[1].Value);
    }
}