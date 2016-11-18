namespace OpenParser.EventResults
{
    public class SkillUp : EventResult
    {
        public SkillUp(LogEntry entry, string skill, short skillLevel) : base(entry)
        {
            Name = skill;
            Level = skillLevel;
        }

        public string Name { get; }
        public short Level { get; }
    }
}