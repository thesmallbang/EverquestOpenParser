using System;
using OpenParser.Constants;

namespace OpenParser.HandlerObjects
{
    public class Say : IResult
    {
        [Flags]
        public enum OriginOptions
        {
            Unknown = 0,
            Player = 1,
            Npc = 2
        }

        public Say(OriginOptions origin, LogEntry entry)
        {
            Origin = origin;
            LogEntry = entry;
        }

        public OriginOptions Origin { get; }
        public string From { get; private set; }
        public string Message { get; private set; }

        public LogEntry LogEntry { get; set; }

        public static OriginOptions GetOrigin(LogEntry entry)
        {
            if (entry.Text.IsRegexMatch(Chat.PlayerSayRegex))
                return OriginOptions.Player;

            if (entry.Text.IsRegexMatch(Chat.NpcSayRegex))
                return OriginOptions.Npc;

            return OriginOptions.Unknown;
        }


        public static Say Create(OriginOptions origin, LogEntry entry)
        {
            if (origin == OriginOptions.Unknown)
                return new Say(origin, entry);

            return new Say(origin, entry)
            {
                From =
                    origin == OriginOptions.Player
                        ? entry.Text.GetLeftText(Chat.PlayerSayId)
                        : entry.Text.GetLeftText(Chat.NpcSayId),
                Message =
                    origin == OriginOptions.Player
                        ? entry.Text.GetRightText(Chat.PlayerSayId)
                        : entry.Text.GetRightText(Chat.NpcSayId)
            };
        }
    }
}