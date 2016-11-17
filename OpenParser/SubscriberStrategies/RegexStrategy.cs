using System;
using System.Text.RegularExpressions;

namespace OpenParser.SubscriberStrategies
{
    public class RegexStrategy<T> : ISubscriberStrategy<T>
    {
        public RegexStrategy(Regex regex, Func<LogEntry, Match, T> resultHandler)
        {
            Regex = regex;
            ResultHandler = resultHandler;
        }


        private Func<LogEntry, Match, T> ResultHandler { get; }
        private Regex Regex { get; }

        public virtual bool IsMatch(LogEntry entry)
        {
            return entry.Text.IsRegexMatch(Regex);
        }

        public virtual T GetResult(LogEntry entry)
        {
            return ResultHandler(entry, entry.Text.RegexMatches(Regex));
        }
    }
}