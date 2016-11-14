using System;
using System.Collections.Generic;
using System.Linq;
using OpenParser.HandlerObjects;
using OpenParser.Subscribers.Strategies.Combat;

namespace OpenParser.Subscribers
{
    public class CombatSubscription : ISubscription
    {
        public CombatSubscription(LogFile logFile, ICombatStrategy strategy)
        {
            LogFile = logFile;
            Strategy = strategy;
            Enable();
        }

        private LogFile LogFile { get; }
        private bool Enabled { get; set; }
        private ICombatStrategy Strategy { get; }


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

        public event EventHandler<Combat> Received;

        private void LogFile_OnChanged(object sender, IEnumerable<LogEntry> logEntries)
        {
            foreach (var entry in logEntries.ToList())
                if (Strategy.IsMatch(entry))
                    TriggerReceived(Strategy.GetCombatInfo(entry));
        }

        private void TriggerReceived(Combat damage)
        {
            Received?.Invoke(this, damage);
        }
    }
}