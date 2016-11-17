using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.EventResults.Combat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class DeathSubscription : Subscription<Combat<EmptyInfo>>
    {
        public DeathSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Combat<EmptyInfo>>(logFile,
                new RegexStrategy<Combat<EmptyInfo>>(CompiledRegex.DeathRegex, HandleMatches));
            Subscribe();
        }

        private Combat<EmptyInfo> HandleMatches(LogEntry entry, Match match)
        {
            var target1 = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var target2 = match.Groups[4].Value.AttemptCharacterNameReplace(LogFile.Character);

            var checkDirection = match.Groups[3].Value;
            var attacker = checkDirection.Contains("by") ? target2 : target1;
            var attacked = checkDirection.Contains("by") ? target1 : target2;

            return new Combat<EmptyInfo>(entry, attacker, attacked, EmptyInfo.Instance());
        }
    }
}