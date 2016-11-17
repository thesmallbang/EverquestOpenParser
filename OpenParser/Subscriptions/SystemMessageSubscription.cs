using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class SystemMessageSubscription : Subscription<string>
    {
        public SystemMessageSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<string>(logFile,
                new RegexStrategy<string>(Misc.SystemMessageRegex, HandleMatches));
            Subscribe();
        }

        private string HandleMatches(LogEntry entry, Match match) => match.Groups[1].Value;
    }
}