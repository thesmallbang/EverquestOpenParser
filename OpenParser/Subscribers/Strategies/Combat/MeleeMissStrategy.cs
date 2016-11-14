using OpenParser.HandlerObjects;

namespace OpenParser.Subscribers.Strategies.Combat
{
    public class MeleeMissStrategy : IMissStrategy
    {
        public HandlerObjects.Combat GetCombatInfo(LogEntry entry)
        {
            var matches = entry.Text.RegexMatches(Constants.Combat.MissRegex);

            var missType = !string.IsNullOrEmpty(matches.Groups[8].Value)
                ? matches.Groups[8].Value
                : matches.Groups[7].Value;

            var damage = new HandlerObjects.Combat
            {
                Attacker = matches.Groups[1].Value,
                Target = matches.Groups[4].Value,
                Info = GetMissInfo(matches.Groups[3].Value, missType),
                LogEntry = entry
            };

            return damage;
        }

        public bool IsMatch(LogEntry entry)
        {
            var matchDamage = entry.Text.IsRegexMatch(Constants.Combat.MissRegex);
            return matchDamage && !ParseHelper.IsPlayerMessage(entry.Text);
        }

        private ICombatInfo GetMissInfo(string attemptType, string missType)
        {
            return new MeleeMissInfo {AttemptType = attemptType, MissType = missType};
        }
    }
}