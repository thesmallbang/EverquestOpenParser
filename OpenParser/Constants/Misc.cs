namespace OpenParser.Constants
{
    public static class Misc
    {
        public const string FactionRegex =
            @"\AYour faction standing with (.+?) (has been adjusted by (-?)(.+)|could not possibly get any (better|worse)).$";

        public const string ExperienceRegex = @"\AYou gain (?:(party) )?experience!!$";
    }
}