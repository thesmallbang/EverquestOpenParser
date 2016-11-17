using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class ExperienceSubscription : Subscription<Experience>
    {
        public ExperienceSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Experience>(logFile,
                new RegexStrategy<Experience>(CompiledRegex.ExperienceRegex, HandleMatches));
            Subscribe();
        }

        private Experience HandleMatches(LogEntry entry, Match match)
        {
            var isParty = !string.IsNullOrEmpty(match.Groups[1].Value);

            return new Experience(entry, isParty);
        }
    }
}