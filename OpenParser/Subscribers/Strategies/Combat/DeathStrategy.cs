using OpenParser.HandlerObjects;

namespace OpenParser.Subscribers.Strategies.Combat
{
    public class DeathStrategy : ICombatStrategy
    {
        public HandlerObjects.Combat GetCombatInfo(LogEntry entry)
        {
            var matches = entry.Text.RegexMatches(Constants.Combat.DeathRegex);

            var combat = new HandlerObjects.Combat();

            switch (matches.Groups[2].Value)
            {
                case "have":
                    if (matches.Groups[3].Value == "slain")
                        combat = new HandlerObjects.Combat
                        {
                            Attacker = matches.Groups[1].Value,
                            Target = matches.Groups[4].Value
                        };
                    else
                        combat = new HandlerObjects.Combat
                        {
                            Attacker = matches.Groups[4].Value,
                            Target = matches.Groups[1].Value
                        };
                    break;
                case "has":
                    combat = new HandlerObjects.Combat
                    {
                        Attacker = matches.Groups[4].Value,
                        Target = matches.Groups[1].Value
                    };

                    break;
            }


            combat.Info = new DeathInfo();
            combat.LogEntry = entry;

            return combat;
        }

        public bool IsMatch(LogEntry entry)
        {
            var matchDamage = entry.Text.IsRegexMatch(Constants.Combat.DeathRegex);
            return matchDamage && !ParseHelper.IsPlayerMessage(entry.Text);
        }
    }
}