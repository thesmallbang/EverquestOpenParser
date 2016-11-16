namespace OpenParser.Constants
{
    public class Chat
    {
        public const string TellRegex = @"\A([^,]+?) tells you, '(.+)'$";
        public const string SayRegex = @"\A(.+?) (say|says)(,?) '(.+)'$";
        public const string ShoutRegex = @"\A(.+?) (shout|shouts)(,?) '(.+)'$";
        public const string OocRegex = @"\A(.+?) (say|says) out of character(,?) '(.+)'$";
        public const string GroupRegex = @"\A(.+?) (tell|tells) (the|your) (group|party)(,?) '(.+)'$";
    }
}