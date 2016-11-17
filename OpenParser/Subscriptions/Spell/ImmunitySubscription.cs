using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Spell
{
    public class ImmunitySubscription : Subscription<EventResult<string>>
    {
        public ImmunitySubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<EventResult<string>>(logFile,
                new RegexStrategy<EventResult<string>>(CompiledRegex.SpellImmunityRegex, HandleMatches));
            Subscribe();
        }

        private EventResult<string> HandleMatches(LogEntry entry, Match match)
            => new EventResult<string>(entry, match.Groups[1].Value);
    }
}