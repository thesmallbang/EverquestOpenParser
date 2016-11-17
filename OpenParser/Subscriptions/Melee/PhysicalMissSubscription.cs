using System.Text.RegularExpressions;
using OpenParser.EventResults.Combat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Melee
{
    public class PhysicalMissSubscription : Subscription<Combat<MeleeMissInfo>>
    {
        public PhysicalMissSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Combat<MeleeMissInfo>>(logFile,
                new RegexStrategy<Combat<MeleeMissInfo>>(CompiledRegex.MissRegex, HandleMatches));
            Subscribe();
        }


        private Combat<MeleeMissInfo> HandleMatches(LogEntry entry, Match match)
        {
            var attacker = match.Groups[1].Value;
            var attacked = match.Groups[4].Value;

            var attemptType = match.Groups[3].Value;

            var missType = !string.IsNullOrEmpty(match.Groups[8].Value)
                ? match.Groups[8].Value
                : match.Groups[7].Value;

            return new Combat<MeleeMissInfo>(entry, attacker, attacked, new MeleeMissInfo(attemptType, missType));
        }
    }
}