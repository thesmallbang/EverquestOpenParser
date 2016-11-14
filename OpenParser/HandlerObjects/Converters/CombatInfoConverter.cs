namespace OpenParser.HandlerObjects.Converters
{
    public static class CombatInfoConverter
    {
        public static T AsInfo<T>(this ICombatInfo info)
            where T : ICombatInfo
        {
            return (T) info;
        }
    }
}