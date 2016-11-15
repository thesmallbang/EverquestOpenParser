﻿using System;
using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class DeathSubscription : ISubscription
    {
        public DeathSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Combat<EmptyInfo>>(logFile,
                new RegexStrategy<Combat<EmptyInfo>>(Combat.DeathRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        private Subscriber<Combat<EmptyInfo>> Subscriber { get; }

        public void Enable()
        {
            Subscriber.Enable();
        }

        public void Disable()
        {
            Subscriber.Disable();
        }

        public event EventHandler<Combat<EmptyInfo>> DeathReceived;

        private void Subscriber_Received(object sender, Combat<EmptyInfo> e)
        {
            DeathReceived?.Invoke(sender, e);
        }

        private Combat<EmptyInfo> HandleMatches(LogEntry entry, Match match)
        {
            var target1 = match.Groups[1].Value;
            var target2 = match.Groups[4].Value;

            var checkDirection = match.Groups[3].Value;
            var attacker = checkDirection.Contains("by") ? target2 : target1;
            var attacked = checkDirection.Contains("by") ? target1 : target2;

            return new Combat<EmptyInfo>(entry, attacker, attacked, EmptyInfo.Instance());
        }
    }
}