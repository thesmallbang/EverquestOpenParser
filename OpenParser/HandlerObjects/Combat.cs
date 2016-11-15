namespace OpenParser.HandlerObjects
{
    public class Combat<T>
        where T : ICombatInfo
    {
        public Combat(LogEntry entry, string attacker, string target, T info)
        {
            LogEntry = entry;
            Attacker = attacker;
            Target = target;
            Info = info;
        }

        public string Attacker { get; }
        public string Target { get; }

        public T Info { get; }
        public LogEntry LogEntry { get; }
    }
}