using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class SkillUpSubscription : Subscription<SkillUp>
    {
        public SkillUpSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<SkillUp>(logFile,
                new RegexStrategy<SkillUp>(CompiledRegex.SkillUpRegex, HandleMatches));
            Subscribe();
        }


        private SkillUp HandleMatches(LogEntry entry, Match match)
        {
            var skillName = match.Groups[1].Value;

            short skillLevel;
            short.TryParse(match.Groups[2].Value, out skillLevel);

            return new SkillUp(entry, skillName, skillLevel);
        }
    }
}