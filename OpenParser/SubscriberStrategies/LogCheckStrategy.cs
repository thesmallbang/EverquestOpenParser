using System;

namespace OpenParser.SubscriberStrategies
{
    public class LogCheckStrategy<T> : ISubscriberStrategy<T>
    {
        public LogCheckStrategy(Func<LogEntry, bool> check, Func<LogEntry, T> resultHandler)
        {
            Check = check;
            ResultHandler = resultHandler;
        }


        private Func<LogEntry, T> ResultHandler { get; }
        private Func<LogEntry, bool> Check { get; }

        public bool IsMatch(LogEntry entry)
        {
            return Check(entry);
        }

        public T GetResult(LogEntry entry)
        {
            return ResultHandler(entry);
        }
    }
}