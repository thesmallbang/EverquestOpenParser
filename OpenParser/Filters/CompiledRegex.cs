using System.Text.RegularExpressions;

namespace OpenParser.Filters
{
    //switching from string to compiled regex which made more sense (seen in https://github.com/rumstil/eqlogparser/blob/master/core/LogParser.cs) 

    public static class CompiledRegex
    {
        public static Regex TellRegex { get; } = new Regex(@"\A(.+?) (told|tells) (\w*?)(,?) '(.+)'$",
            RegexOptions.Compiled);

        public static Regex SayRegex { get; } = new Regex(@"\A(.+?) (say|says)(,?) '(.+)'$", RegexOptions.Compiled);

        public static Regex ShoutRegex { get; } = new Regex(@"\A(.+?) (shout|shouts)(,?) '(.+)'$", RegexOptions.Compiled)
            ;

        public static Regex OocRegex { get; } = new Regex(@"\A(.+?) (say|says) out of character(,?) '(.+)'$",
            RegexOptions.Compiled);

        public static Regex GroupRegex { get; } = new Regex(
            @"\A(.+?) (tell|tells) (the|your) (group|party)(,?) '(.+)'$", RegexOptions.Compiled);

        public static Regex GuildRegex { get; } = new Regex(@"\A(.+?) (say|tells) (the|to your) guild(,?) '(.+)'$",
            RegexOptions.Compiled);

        public static Regex ChannelRegex { get; } = new Regex(@"\A(.+?) (tell|tells) (\w+):(\d+), '(.+)'$",
            RegexOptions.Compiled);

        public static Regex AuctionRegex { get; } = new Regex(@"\A(.+?) (auction|auctions)?, '(.+)'$",
            RegexOptions.Compiled);

        public static Regex DamageRegex { get; } =
            new Regex(
                @"\A(.+?) (slash|hit|kick|pierce|bash|punch|crush|bite|maul|backstab|claw|strike)(?:s|es)? (?!by non-melee)(.+?) for (\d+) points? of damage\.",
                RegexOptions.Compiled)
            ;

        public static Regex DamageShieldRegex { get; } =
            new Regex(
                @"\A(.+?) is (\w+) by (.+?) (\w+) for (\d+) points of non-melee damage\.$",
                RegexOptions.Compiled);


        public static Regex MissRegex { get; } =
            new Regex(@"\A(.+?) (tries|try) to (\w+) (.+?), but ((.+?) (\w+)|(\w+))!$", RegexOptions.Compiled);

        public static Regex DeathRegex { get; } = new Regex(@"\A(.+?) (have|has) (been slain by|slain) (.+?)!$",
            RegexOptions.Compiled);

        public static Regex DotRegex { get; } =
            new Regex(@"\A(.+?) (have|has) taken (\d+) damage from (your|.+) (by?)\ ?(.+).$", RegexOptions.Compiled);


        public static Regex FactionRegex { get; } =
            new Regex(
                @"\AYour faction standing with (.+?) (has been adjusted by (-?)(.+)|could not possibly get any (better|worse))\.$",
                RegexOptions.Compiled);

        public static Regex ExperienceRegex { get; } =
            new Regex(@"\AYou gain (?:(party) )?experience!!$", RegexOptions.Compiled);

        public static Regex SpellWoreRegex { get; } =
            new Regex(@"\AYour (.+?) spell has worn off\.$", RegexOptions.Compiled | RegexOptions.RightToLeft);

        public static Regex SpellImmunityRegex { get; } = new Regex(@"\AYour target is immune to (.+)$",
            RegexOptions.Compiled);

        public static Regex ZoneRegex { get; } = new Regex(@"\AYou have entered (.+)\.$", RegexOptions.Compiled);

        public static Regex SystemMessageRegex { get; } =
            new Regex(@"\A<SYSTEMWIDE_MESSAGE>: ?(.+?)$", RegexOptions.Compiled);
    }
}