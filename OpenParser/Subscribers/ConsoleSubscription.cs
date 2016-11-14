using System.Collections.Generic;
using System.Diagnostics;

namespace OpenParser.Subscribers
{
    public class ConsoleSubscription : ISubscription
    {
        public ConsoleSubscription(LogFile logFile)
        {
            LogFile = logFile;
            Enable();
        }

        private LogFile LogFile { get; }
        private bool Enabled { get; set; }

        public void Enable()
        {
            if (!Enabled)
                LogFile.OnChanged += LogFile_OnChanged;
        }

        public void Disable()
        {
            if (Enabled)
                LogFile.OnChanged -= LogFile_OnChanged;
        }

        private void LogFile_OnChanged(object sender, IEnumerable<LogEntry> logEntries)
        {
            foreach (var entry in logEntries)
                Debug.Print(entry.Raw);
        }
    }
}