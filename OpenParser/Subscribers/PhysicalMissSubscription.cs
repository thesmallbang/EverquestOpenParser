using System;
using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.HandlerObjects;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class PhysicalMissSubscription : ISubscription
    {
        public PhysicalMissSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Combat<MeleeMissInfo>>(logFile,
                new RegexStrategy<Combat<MeleeMissInfo>>(Combat.MissRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        private Subscriber<Combat<MeleeMissInfo>> Subscriber { get; }

        public void Enable()
        {
            Subscriber.Enable();
        }

        public void Disable()
        {
            Subscriber.Disable();
        }

        public event EventHandler<Combat<MeleeMissInfo>> MissReceived;

        private void Subscriber_Received(object sender, Combat<MeleeMissInfo> e)
        {
            MissReceived?.Invoke(sender, e);
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