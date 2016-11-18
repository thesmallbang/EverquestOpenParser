using System.Text.RegularExpressions;
using OpenParser.EventResults.Combat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Spell
{
    public class DamageShieldSubscription : Subscription<Combat<DamageShieldInfo>>
    {
        public DamageShieldSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Combat<DamageShieldInfo>>(logFile,
                new RegexStrategy<Combat<DamageShieldInfo>>(CompiledRegex.DamageRegex, HandleMatches));
            Subscribe();
        }


        private Combat<DamageShieldInfo> HandleMatches(LogEntry entry, Match match)
        {
            var attacker = match.Groups[3].Value.AttemptCharacterNameReplace(LogFile.Character);
            var target = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var damageSource = match.Groups[2].Value;
            var affectType = match.Groups[4].Value;

            long damage;
            long.TryParse(match.Groups[5].Value, out damage);

            return new Combat<DamageShieldInfo>(entry, attacker.AttemptCharacterNameReplace(LogFile.Character),
                target.AttemptCharacterNameReplace(LogFile.Character),
                new DamageShieldInfo(damage, damageSource, affectType));
        }
    }
}