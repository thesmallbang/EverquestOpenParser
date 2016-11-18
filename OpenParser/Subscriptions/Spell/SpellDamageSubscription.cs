using System.Text.RegularExpressions;
using OpenParser.EventResults.Combat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Spell
{
    public class SpellDamageSubscription : Subscription<Combat<DamageInfo>>
    {
        public SpellDamageSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Combat<DamageInfo>>(logFile,
                new RegexStrategy<Combat<DamageInfo>>(CompiledRegex.SpellDamageRegex, HandleMatches));
            Subscribe();
        }


        private Combat<DamageInfo> HandleMatches(LogEntry entry, Match match)
        {
            var attacker = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var target = match.Groups[2].Value.AttemptCharacterNameReplace(LogFile.Character);

            long damage;
            long.TryParse(match.Groups[3].Value, out damage);

            return new Combat<DamageInfo>(entry, attacker.AttemptCharacterNameReplace(LogFile.Character),
                target.AttemptCharacterNameReplace(LogFile.Character),
                new DamageInfo(damage, "non-melee"));
        }
    }
}