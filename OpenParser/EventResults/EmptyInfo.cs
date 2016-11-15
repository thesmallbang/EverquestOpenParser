namespace OpenParser.EventResults
{
    public class EmptyInfo : ICombatInfo
    {
        private EmptyInfo()
        {
        }

        public static EmptyInfo Instance()
        {
            return new EmptyInfo();
        }
    }
}