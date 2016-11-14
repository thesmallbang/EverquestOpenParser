using OpenParser.Constants;

namespace OpenParser.HandlerObjects
{
    public class Tell : IResult
    {
        private Tell()
        {
        }

        public string From { get; set; }
        public string Message { get; set; }

        public LogEntry LogEntry { get; set; }

        public static Tell Create(LogEntry entry)
        {
            return new Tell
            {
                From = entry.Text.GetLeftText(Chat.TellId),
                Message = entry.Text.GetRightText(Chat.TellId),
                LogEntry = entry
            };
        }
    }
}