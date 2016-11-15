using System;
using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class PhysicalHitSubscription : ISubscription
    {
        public PhysicalHitSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Combat<MeleeDamageInfo>>(logFile,
                new RegexStrategy<Combat<MeleeDamageInfo>>(Combat.DamageRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        private Subscriber<Combat<MeleeDamageInfo>> Subscriber { get; }

        public void Enable()
        {
            Subscriber.Enable();
        }

        public void Disable()
        {
            Subscriber.Disable();
        }

        public event EventHandler<Combat<MeleeDamageInfo>> HitReceived;

        private void Subscriber_Received(object sender, Combat<MeleeDamageInfo> e)
        {
            HitReceived?.Invoke(sender, e);
        }

        private Combat<MeleeDamageInfo> HandleMatches(LogEntry entry, Match match)
        {
            var attacker = match.Groups[1].Value;
            var target = match.Groups[3].Value;
            var damageType = match.Groups[2].Value;

            long damage;
            long.TryParse(match.Groups[4].Value, out damage);

            return new Combat<MeleeDamageInfo>(entry, attacker, target, new MeleeDamageInfo(damage, damageType));
        }
    }
}