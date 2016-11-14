namespace OpenParser.HandlerObjects
{
    public class Combat : IResult
    {
        public string Attacker { get; set; }
        public string Target { get; set; }

        public ICombatInfo Info { get; set; }
        public LogEntry LogEntry { get; set; }
    }
}