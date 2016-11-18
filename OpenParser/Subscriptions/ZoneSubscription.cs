using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class ZoneSubscription : Subscription<EventResult<string>>
    {
        public ZoneSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<EventResult<string>>(logFile,
                new RegexStrategy<EventResult<string>>(CompiledRegex.ZoneRegex, HandleMatches));
            Subscribe();
        }

        private EventResult<string> HandleMatches(LogEntry entry, Match match)
        {
            var firstChar = match.Groups[1].Value.Substring(0, 1);

            //not starting with an uppercase letter indicates it is not an actual zoning message
            //need feedback/testing to validate this is 100% accurate. I wanted to avoid specific checks for known non zone messages that follow this format.
            if (firstChar.ToLower() == firstChar)
                return null;

            return new EventResult<string>(entry, match.Groups[1].Value);
        }
    }
}