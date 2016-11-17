using System.Text.RegularExpressions;
using OpenParser.EventResults.Combat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Melee
{
    public class PhysicalHitSubscription : Subscription<Combat<MeleeDamageInfo>>
    {
        public PhysicalHitSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Combat<MeleeDamageInfo>>(logFile,
                new RegexStrategy<Combat<MeleeDamageInfo>>(CompiledRegex.DamageRegex, HandleMatches));
            Subscribe();
        }


        private Combat<MeleeDamageInfo> HandleMatches(LogEntry entry, Match match)
        {
            var attacker = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var target = match.Groups[3].Value.AttemptCharacterNameReplace(LogFile.Character);
            var damageType = match.Groups[2].Value;

            long damage;
            long.TryParse(match.Groups[4].Value, out damage);

            return new Combat<MeleeDamageInfo>(entry, attacker, target, new MeleeDamageInfo(damage, damageType));
        }
    }
}