namespace OpenParser.Constants
{
    public class Chat
    {
        public const string TellRegex = @"\A([^,]+?) tells you, '(.+)'$";
        public const string SayRegex = @"\A(.+?) says(,?) '(.+)'$";
        public const string ShoutRegex = @"\A(.+?) shout(s?), '(.+)'";
    }
}