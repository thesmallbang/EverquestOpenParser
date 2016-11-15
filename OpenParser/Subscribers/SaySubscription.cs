using System;
using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.Enums;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class SaySubscription : ISubscription
    {
        public SaySubscription(LogFile logFile)
        {
            OriginCheck = SayOrigins.Npc | SayOrigins.Player | SayOrigins.Unknown;
            Subscriber = new Subscriber<Say>(logFile, new RegexStrategy<Say>(Chat.SayRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        public SaySubscription(LogFile logFile, SayOrigins originOptions)
        {
            OriginCheck = originOptions;
            Subscriber = new Subscriber<Say>(logFile, new RegexStrategy<Say>(Chat.SayRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        public SayOrigins OriginCheck { get; set; }

        private Subscriber<Say> Subscriber { get; }

        public void Enable()
        {
            Subscriber.Enable();
        }

        public void Disable()
        {
            Subscriber.Disable();
        }

        public event EventHandler<Say> SayReceived;

        private void Subscriber_Received(object sender, Say e)
        {
            if (OriginCheck.HasFlag(e.Origin))
                SayReceived?.Invoke(sender, e);
        }

        private Say HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var originCheck = match.Groups[2].Value;
            var message = match.Groups[3].Value;

            var origin = SayOrigins.Player;

            if (originCheck == string.Empty)
                origin = SayOrigins.Npc;

            return new Say(entry, origin, from, message);
        }
    }
}