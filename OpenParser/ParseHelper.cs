using System;
using System.Globalization;
using System.Text.RegularExpressions;
using OpenParser.Constants;

namespace OpenParser
{
    public static class ParseHelper
    {
        public static DateTime DateFromEntry(this string entry)
        {
            if (string.IsNullOrWhiteSpace(entry))
                return DateTime.MinValue;

            return DateTime.ParseExact(entry.Substring(1, 24), "ddd MMM dd HH:mm:ss yyyy", CultureInfo.CurrentCulture);
        }

        public static string TextFromEntry(this string entry)
        {
            return entry.StartsWith("[") ? entry.Substring(27) : entry;
        }

        public static bool IsRegexMatch(this string entry, string regex)
        {
            var m = Regex.Match(entry, regex, RegexOptions.IgnoreCase);
            return m.Success;
        }


        public static Match RegexMatches(this string entry, string regex)
        {
            var matches = Regex.Match(entry, regex, RegexOptions.IgnoreCase);
            return matches;
        }

        public static string AddSpaces(this string text)
        {
            if (!text.StartsWith(" "))
                text = " " + text;

            if (!text.EndsWith(" "))
                text += " ";

            return text;
        }

        public static bool IsPlayerMessage(this string text)
        {
            return text.IsRegexMatch("FIXME") || text.IsRegexMatch(Chat.TellRegex);
        }

        public static string GetRightText(this string text, string lookFor)
        {
            var startPosition = text.IndexOf(lookFor, 0, StringComparison.CurrentCulture);

            if (startPosition > -1)
                return text.Substring(startPosition + lookFor.Length);

            return string.Empty;
        }

        public static string GetLeftText(this string text, string lookFor)
        {
            var startPosition = text.IndexOf(lookFor, 0, StringComparison.CurrentCulture);
            if (startPosition > -1)
                return text.Substring(0, startPosition);

            return string.Empty;
        }

        public static string GetBetweenText(this string text, string leftLookFor, string rightLookFor)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var startPosition = text.IndexOf(leftLookFor, 0, StringComparison.CurrentCulture);
            if (startPosition < 0)
                return string.Empty;

            startPosition += leftLookFor.Length;

            var endPosition = text.IndexOf(rightLookFor, 0, StringComparison.CurrentCulture);
            if (endPosition < 0)
                return string.Empty;

            return text.Substring(startPosition, endPosition - startPosition).Trim();
        }
    }
}