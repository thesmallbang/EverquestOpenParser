using System;
using System.Collections.Generic;
using OpenParser.SubscriberStrategies;

namespace OpenParser
{
    public class Subscriber<T> : ISubscriber<T>
    {
        public Subscriber(LogFile logFile, ISubscriberStrategy<T> strategy)
        {
            LogFile = logFile;
            Strategy = strategy;
            LogFile.OnChanged += LogFile_OnChanged;
            Enable();
        }

        private LogFile LogFile { get; }
        private bool Enabled { get; set; }
        private ISubscriberStrategy<T> Strategy { get; }

        public event EventHandler<T> Matched;

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        private void LogFile_OnChanged(object sender, IEnumerable<LogEntry> logEntries)
        {
            if (!Enabled)
                return;

            foreach (var entry in logEntries)
                if (Strategy.IsMatch(entry))
                    TriggerMatched(Strategy.GetResult(entry));
        }

        private void TriggerMatched(T response)
        {
            Matched?.Invoke(this, response);
        }
    }
}