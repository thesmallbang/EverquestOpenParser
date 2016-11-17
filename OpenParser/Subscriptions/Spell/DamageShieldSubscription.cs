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
            string attacker;
            string target;
            string damageSource;

            if (match.Groups[2].Value == "has")
            {
                attacker = match.Groups[4].Value;
                target = match.Groups[1].Value;
                damageSource = match.Groups[6].Value;
            }
            else
            {
                attacker = match.Groups[6].Value;
                target = match.Groups[1].Value;
                damageSource = match.Groups[4].Value;
            }

            long damage;
            long.TryParse(match.Groups[3].Value, out damage);

            return new Combat<DamageShieldInfo>(entry, attacker.AttemptCharacterNameReplace(LogFile.Character),
                target.AttemptCharacterNameReplace(LogFile.Character), new DamageShieldInfo(damage, damageSource, ""));
        }
    }
}