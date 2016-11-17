using System.Text.RegularExpressions;
using OpenParser.EventResults.Chat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Chat
{
    public class TellSubscription : Subscription<Tell>
    {
        public TellSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Tell>(logFile,
                new RegexStrategy<Tell>(CompiledRegex.TellRegex, HandleMatches));
            Subscribe();
        }

        private Tell HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var to = match.Groups[3].Value.AttemptCharacterNameReplace(LogFile.Character);
            var message = match.Groups[5].Value;

            return new Tell(entry, from, to, message);
        }
    }
}