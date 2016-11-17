using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Spell
{
    public class FizzleSubscription : Subscription<Empty>
    {
        public FizzleSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Empty>(logFile,
                new LogCheckStrategy<Empty>(o => o.Text == Misc.FizzleCheck, HandleMatches));
            Subscribe();
        }

        private Empty HandleMatches(LogEntry entry) => Empty.Instance(entry);
    }
}