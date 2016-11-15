using System;
using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.Enums;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class FactionSubscription : ISubscription
    {
        public FactionSubscription(LogFile logFile)
        {
            FactionCheck = FactionChanges.Unknown | FactionChanges.Decrease | FactionChanges.Increase |
                           FactionChanges.MaxNegative | FactionChanges.MaxPositive;
            Subscriber = new Subscriber<Faction>(logFile, new RegexStrategy<Faction>(Misc.FactionRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        public FactionSubscription(LogFile logFile, FactionChanges factionChanges)
        {
            FactionCheck = factionChanges;
            Subscriber = new Subscriber<Faction>(logFile, new RegexStrategy<Faction>(Misc.FactionRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }


        private Subscriber<Faction> Subscriber { get; }
        private FactionChanges FactionCheck { get; }

        public void Enable()
        {
            Subscriber.Enable();
        }

        public void Disable()
        {
            Subscriber.Disable();
        }

        public event EventHandler<Faction> FactionReceived;

        private void Subscriber_Received(object sender, Faction e)
        {
            if (FactionCheck.HasFlag(e.Change))
                FactionReceived?.Invoke(sender, e);
        }

        private Faction HandleMatches(LogEntry entry, Match match)
        {
            var faction = match.Groups[1].Value;

            var isMax = match.Groups[2].Value.StartsWith("could not possibly");
            var amount = 0;

            FactionChanges change;

            if (isMax)
                change = match.Groups[5].Value == "better" ? FactionChanges.MaxPositive : FactionChanges.MaxNegative;
            else
            {
                change = match.Groups[3].Value == "" ? FactionChanges.Increase : FactionChanges.Decrease;
                int.TryParse(match.Groups[4].Value, out amount);
            }
            return new Faction(change, faction, amount);
        }
    }
}