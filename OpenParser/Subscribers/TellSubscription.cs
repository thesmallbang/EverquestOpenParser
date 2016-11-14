using System;
using System.Collections.Generic;
using OpenParser.Constants;
using OpenParser.HandlerObjects;

namespace OpenParser.Subscribers
{
    public class TellSubscription : ISubscription
    {
        public TellSubscription(LogFile logFile)
        {
            LogFile = logFile;
            Enable();
        }

        private LogFile LogFile { get; }
        private bool Enabled { get; set; }

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

        public event EventHandler<Tell> Received;

        private void LogFile_OnChanged(object sender, IEnumerable<LogEntry> logEntries)
        {
            foreach (var entry in logEntries)
                if (entry.Text.IsRegexMatch(Chat.TellRegex))
                    TriggerReceived(Tell.Create(entry));
        }

        private void TriggerReceived(Tell tell)
        {
            Received?.Invoke(this, tell);
        }
    }
}