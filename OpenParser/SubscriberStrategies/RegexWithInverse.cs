using System;
using System.Text.RegularExpressions;

namespace OpenParser.SubscriberStrategies
{
    public class RegexWithInverseStrategy<T> : RegexStrategy<T>
    {
        public RegexWithInverseStrategy(string regex, string inverseRegex, Func<LogEntry, Match, T> resultHandler)
            : base(regex, resultHandler)
        {
            Regex = regex;
            InverseRegex = inverseRegex;
            ResultHandler = resultHandler;
        }


        private Func<LogEntry, Match, T> ResultHandler { get; }
        private string Regex { get; }
        private string InverseRegex { get; }

        public override bool IsMatch(LogEntry entry)
        {
            return base.IsMatch(entry) && !entry.Text.IsRegexMatch(InverseRegex);
        }

        public override T GetResult(LogEntry entry)
        {
            return ResultHandler(entry, entry.Text.RegexMatches(Regex));
        }
    }
}