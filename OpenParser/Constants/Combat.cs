namespace OpenParser.Constants
{
    public class Combat
    {
        public const string DamageRegex =
            @"\A(.+?) (slash|hit|kick|pierce|bash|punch|crush|bite|maul|backstab|claw|strike)(?:s|es)? (?!by non-melee)(.+?) for (\d+) points? of damage\.";

        public const string MissRegex = @"\A(.+?) (tries|try) to (\w+) (.+?), but ((.+?) (\w+)|(\w+))!";

        public const string DeathRegex = @"\A(.+?) (have|has) (been slain by|slain) (.+?)!";
    }
}