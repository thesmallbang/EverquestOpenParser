namespace OpenParser.EventResults
{
    public class MeleeMissInfo : ICombatInfo
    {
        public MeleeMissInfo(string attemptType, string missType)
        {
            AttemptType = attemptType;
            MissType = missType;
        }

        public string AttemptType { get; }
        public string MissType { get; }
    }
}