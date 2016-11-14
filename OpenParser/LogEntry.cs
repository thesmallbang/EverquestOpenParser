using System;

namespace OpenParser
{
    public class LogEntry
    {
        private LogEntry(string raw)
        {
            When = raw.DateFromEntry();
            Text = raw.TextFromEntry();
            Raw = raw;
        }

        public string Text { get; private set; }
        public DateTime When { get; private set; }
        public string Raw { get; private set; }

        public static LogEntry Create(string raw)
        {
            return new LogEntry(raw);
        }
    }
}