using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Spell
{
    public class WornOffSubscription : Subscription<string>
    {
        public WornOffSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<string>(logFile,
                new RegexStrategy<string>(Misc.SpellWoreRegex, HandleMatches));
            Subscribe();
        }


        private string HandleMatches(LogEntry entry, Match match) => match.Groups[1].Value;
    }
}