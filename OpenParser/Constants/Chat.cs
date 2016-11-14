namespace OpenParser.Constants
{
    public class Chat
    {
        public const string TellId = " tells you, '";
        public const string TellRegex = @"^(?:[A-Z][a-z]+)\s+(tells you, ')";

        public const string PlayerSayId = " says, '";
        public const string PlayerSayRegex = @"^(?:[A-Z][a-z]+)\s+(says, ')";

        public const string NpcSayId = " says '";
        public const string NpcSayRegex = @"^.+(says ')";
    }
}