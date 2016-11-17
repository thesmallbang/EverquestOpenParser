using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults.Combat;
using OpenParser.Subscriptions.Strategies;

namespace OpenParser.Subscriptions.Spell
{
    public class DotSubscription : Subscription<Combat<SpellDamageInfo>>
    {
        public DotSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Combat<SpellDamageInfo>>(logFile,
                new RegexStrategy<Combat<SpellDamageInfo>>(Combat.DamageRegex, HandleMatches));
            Subscribe();
        }


        private Combat<SpellDamageInfo> HandleMatches(LogEntry entry, Match match)
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

            return new Combat<SpellDamageInfo>(entry, attacker, target, new SpellDamageInfo(damage, damageSource));
        }
    }
}