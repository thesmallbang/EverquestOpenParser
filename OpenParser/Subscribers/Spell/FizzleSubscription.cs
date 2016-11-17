﻿using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers.Spell
{
    public class FizzleSubscription : Subscription<Empty>
    {
        public FizzleSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Empty>(logFile,
                new LogCheckStrategy<Empty>(o => o.Text == Combat.FizzleCheck, HandleMatches));
            Subscribe();
        }

        private Empty HandleMatches(LogEntry entry) => Empty.Instance(entry);
    }
}