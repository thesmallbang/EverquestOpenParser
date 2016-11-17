namespace OpenParser.Constants
{
    //**
    //** Some expressions taken/modified from http://search.cpan.org/~pjf/Games-EverQuest-LogLineParser-0.09/lib/Games/EverQuest/LogLineParser.pm
    //**


    public class Combat
    {
        public const string DamageRegex =
            @"\A(.+?) (slash|hit|kick|pierce|bash|punch|crush|bite|maul|backstab|claw|strike)(?:s|es)? (?!by non-melee)(.+?) for (\d+) points? of damage\.";

        public const string MissRegex = @"\A(.+?) (tries|try) to (\w+) (.+?), but ((.+?) (\w+)|(\w+))!$";

        public const string DeathRegex = @"\A(.+?) (have|has) (been slain by|slain) (.+?)!$";

        public const string DotRegex = @"\A(.+?) (have|has) taken (\d+) damage from (your|.+) (by?)\ ?(.+).$";

        public const string FizzleCheck = "Your spell Fizzles!";
    }
}