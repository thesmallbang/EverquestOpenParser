namespace OpenParser.EventResults
{
    public class EmptyInfo : ICombatInfo
    {
        private EmptyInfo()
        {
        }

        public static EmptyInfo Instance() => new EmptyInfo();
    }
}