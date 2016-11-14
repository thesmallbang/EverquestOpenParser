using System;
using OpenParser.HandlerObjects;

namespace OpenParser.Subscribers.Strategies.Combat
{
    public class MeleeHitStrategy : IHitStrategy
    {
        public HandlerObjects.Combat GetCombatInfo(LogEntry entry)
        {
            var matches = entry.Text.RegexMatches(Constants.Combat.DamageRegex);

            var damage = new HandlerObjects.Combat
            {
                Attacker = matches.Groups[1].Value,
                Target = matches.Groups[3].Value,
                Info = GetDamageInfo(Convert.ToInt64(matches.Groups[4].Value), matches.Groups[2].Value, false),
                LogEntry = entry
            };

            return damage;
        }

        public bool IsMatch(LogEntry entry)
        {
            var matchDamage = entry.Text.IsRegexMatch(Constants.Combat.DamageRegex);
            return matchDamage && !ParseHelper.IsPlayerMessage(entry.Text);
        }

        private MeleeDamageInfo GetDamageInfo(long amount, string damageType, bool critical)
        {
            return new MeleeDamageInfo
            {
                Amount = amount,
                DamageType = damageType,
                IsCritical = critical
            };
        }
    }
}