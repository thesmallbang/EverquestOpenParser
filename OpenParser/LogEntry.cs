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

        private LogEntry()
        {
        }

        public string Text { get; private set; }
        public DateTime When { get; private set; }
        public string Raw { get; private set; }

        public static LogEntry Invalid() => new LogEntry();

        public static LogEntry Create(string raw)
        {
            try
            {
                return new LogEntry(raw);
            }
            catch (Exception)
            {
                return Invalid();
            }
        }
    }
}