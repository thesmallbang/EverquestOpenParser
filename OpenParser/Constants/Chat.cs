namespace OpenParser.Constants
{
    public class Chat
    {
        public const string TellRegex = @"\A(.+?) (told|tells) (\w*?)(,?) '(.+)'$";
        public const string SayRegex = @"\A(.+?) (say|says)(,?) '(.+)'$";
        public const string ShoutRegex = @"\A(.+?) (shout|shouts)(,?) '(.+)'$";
        public const string OocRegex = @"\A(.+?) (say|says) out of character(,?) '(.+)'$";
        public const string GroupRegex = @"\A(.+?) (tell|tells) (the|your) (group|party)(,?) '(.+)'$";
        public const string GuildRegex = @"\A(.+?) (say|tells) (the|to your) guild(,?) '(.+)'$";
    }
}