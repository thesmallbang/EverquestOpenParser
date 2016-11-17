namespace OpenParser.EventResults.Combat
{
    public class Combat<T> : EventResult
        where T : ICombatInfo
    {
        public Combat(LogEntry entry, string attacker, string target, T info) : base(entry)
        {
            Attacker = attacker;
            Target = target;
            Info = info;
        }

        public string Attacker { get; }
        public string Target { get; }

        public T Info { get; }
    }
}