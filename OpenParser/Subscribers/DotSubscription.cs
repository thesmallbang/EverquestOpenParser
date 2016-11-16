using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class DotSubscription : Subscription<Combat<DotDamageInfo>>
    {
        public DotSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Combat<DotDamageInfo>>(logFile,
                new RegexStrategy<Combat<DotDamageInfo>>(Combat.DamageRegex, HandleMatches));
            Subscribe();
        }


        private Combat<DotDamageInfo> HandleMatches(LogEntry entry, Match match)
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

            return new Combat<DotDamageInfo>(entry, attacker, target, new DotDamageInfo(damage, damageSource));
        }
    }
}