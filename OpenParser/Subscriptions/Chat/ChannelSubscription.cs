using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenParser.EventResults.Chat;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Chat
{
    public class ChannelSubscription : Subscription<ChannelMessage>
    {
        public ChannelSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChannelMessage>(logFile,
                new RegexStrategy<ChannelMessage>(Constants.Chat.ChannelRegex, HandleMatches));
            Subscribe();
        }

        public ChannelSubscription(LogFile logFile, string channel)
        {
            ChannelFilters = new List<string> {channel};
            Subscriber = new Subscriber<ChannelMessage>(logFile,
                new RegexStrategy<ChannelMessage>(Constants.Chat.ChannelRegex, HandleMatches));
            Subscribe();
        }

        public ChannelSubscription(LogFile logFile, List<string> channels)
        {
            ChannelFilters = channels;
            Subscriber = new Subscriber<ChannelMessage>(logFile,
                new RegexStrategy<ChannelMessage>(Constants.Chat.ChannelRegex, HandleMatches));
            Subscribe();
        }

        private List<string> ChannelFilters { get; } = new List<string>();

        protected override void Subscriber_Matched(object sender, ChannelMessage e)
        {
            if (!ChannelFilters.Any() || ChannelFilters.Any(o => o.ToLower() == e.Channel))
                base.Subscriber_Matched(sender, e);
        }

        private ChannelMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var channel = match.Groups[3].Value.Trim();
            byte channelNumber;
            byte.TryParse(match.Groups[4].Value, out channelNumber);

            var message = match.Groups[5].Value;

            return new ChannelMessage(entry, from, channel, channelNumber, message);
        }
    }
}