using System;
using System.Collections.Generic;
using OpenParser.HandlerObjects;
using OpenParser.Subscribers.Strategies.Say;

namespace OpenParser.Subscribers
{
    public class SaySubscription : ISubscription
    {
        public SaySubscription(LogFile logFile, ISayStrategy strategy)
        {
            LogFile = logFile;
            Strategy = strategy;
            Enable();
        }

        private LogFile LogFile { get; }
        private bool Enabled { get; set; }
        private ISayStrategy Strategy { get; }


        public void Enable()
        {
            if (Enabled)
                return;

            LogFile.OnChanged += LogFile_OnChanged;
            Enabled = true;
        }

        public void Disable()
        {
            if (!Enabled)
                return;

            LogFile.OnChanged -= LogFile_OnChanged;
            Enabled = false;
        }

        public event EventHandler<Say> Received;

        private void LogFile_OnChanged(object sender, IEnumerable<LogEntry> logEntries)
        {
            foreach (var entry in logEntries)
                if (Strategy.IsMatch(entry))
                    TriggerReceived(Strategy.GetSay(entry));
        }

        private void TriggerReceived(Say say)
        {
            Received?.Invoke(this, say);
        }
    }
}