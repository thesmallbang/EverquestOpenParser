using System;
using System.Text.RegularExpressions;

namespace OpenParser.SubscriberStrategies
{
    public class RegexWithCheckStrategy<T> : RegexStrategy<T>
    {
        public RegexWithCheckStrategy(string regex, Func<LogEntry, bool> check, Func<LogEntry, Match, T> resultHandler)
            : base(regex, resultHandler)
        {
            Regex = regex;
            Check = check;
            ResultHandler = resultHandler;
        }


        private Func<LogEntry, Match, T> ResultHandler { get; }
        private string Regex { get; }
        private Func<LogEntry, bool> Check { get; }

        public override bool IsMatch(LogEntry entry)
        {
            return base.IsMatch(entry) && Check(entry);
        }

        public override T GetResult(LogEntry entry)
        {
            return ResultHandler(entry, entry.Text.RegexMatches(Regex));
        }
    }
}