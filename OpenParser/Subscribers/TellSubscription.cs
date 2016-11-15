using System;
using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class TellSubscription : ISubscription
    {
        public TellSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Tell>(logFile, new RegexStrategy<Tell>(Chat.TellRegex, HandleMatches));
            Subscriber.Received += Subscriber_Received;
        }

        private Subscriber<Tell> Subscriber { get; }

        public void Enable()
        {
            Subscriber.Enable();
        }

        public void Disable()
        {
            Subscriber.Disable();
        }

        public event EventHandler<Tell> TellReceived;

        private void Subscriber_Received(object sender, Tell e)
        {
            TellReceived?.Invoke(sender, e);
        }

        private Tell HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var message = match.Groups[2].Value;

            return new Tell(entry, from, message);
        }
    }
}