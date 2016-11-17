using System.Text.RegularExpressions;
using OpenParser.Constants;
using OpenParser.EventResults;
using OpenParser.EventResults.Chat;
using OpenParser.Subscribers.Strategies;

namespace OpenParser.Subscribers
{
    public class TellSubscription : Subscription<Tell>
    {
        public TellSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<Tell>(logFile,
                new RegexStrategy<Tell>(Chat.TellRegex, HandleMatches));
            Subscribe();
        }

        private Tell HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var to = match.Groups[3].Value.Trim();
            var message = match.Groups[5].Value;

            return new Tell(entry, from, to, message);
        }
    }
}