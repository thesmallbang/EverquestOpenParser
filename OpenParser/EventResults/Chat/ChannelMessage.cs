namespace OpenParser.EventResults.Chat
{
    public class ChannelMessage : ChatMessage
    {
        public ChannelMessage(LogEntry entry, string from, string channel, byte channelNumber, string message)
            : base(entry, from, message)
        {
            Channel = channel;
            ChannelNumber = channelNumber;
        }

        public string Channel { get; private set; }
        public byte ChannelNumber { get; private set; }
    }
}