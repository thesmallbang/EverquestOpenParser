﻿using System.Text.RegularExpressions;
using OpenParser.Enums;
using OpenParser.EventResults.Chat;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Chat
{
    public class SaySubscription : Subscription<Say>
    {
        public SaySubscription(LogFile logFile)
        {
            OriginCheck = SayOrigins.Npc | SayOrigins.Player | SayOrigins.Unknown;
            Subscriber = new Subscriber<Say>(logFile, new RegexStrategy<Say>(Constants.Chat.SayRegex, HandleMatches));
            Subscriber.Matched += Subscriber_Matched;
        }

        public SaySubscription(LogFile logFile, SayOrigins originOptions)
        {
            OriginCheck = originOptions;
            Subscriber = new Subscriber<Say>(logFile, new RegexStrategy<Say>(Constants.Chat.SayRegex, HandleMatches));
            Subscriber.Matched += Subscriber_Matched;
        }

        public SayOrigins OriginCheck { get; set; }

        protected override void Subscriber_Matched(object sender, Say e)
        {
            if (OriginCheck.HasFlag(e.Origin))
                base.Subscriber_Matched(sender, e);
        }

        private Say HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var originCheck = match.Groups[3].Value;
            var message = match.Groups[4].Value;

            var origin = SayOrigins.Player;

            if (originCheck == string.Empty)
                origin = SayOrigins.Npc;

            return new Say(entry, origin, from, message);
        }
    }
}