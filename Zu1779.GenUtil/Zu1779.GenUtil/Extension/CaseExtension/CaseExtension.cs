namespace Zu1779.GenUtil.Extension.CaseExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Zu1779.GenUtil.Extension.BaseTypeExtension;
    using Zu1779.GenUtil.Extension.EnumerableExtension;

    public static class CaseExtension
    {
        public static IEnumerable<string> FromCamelCase(this string text)
        {
            var breakline = Regex.Replace(text, @"([A-Z])", $"\r\n$1");
            var lines = breakline.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToLower();
            return lines;
        }
        public static IEnumerable<string> FromPascalCase(this string text) => text.FromCamelCase();
        public static IEnumerable<string> FromUnderscoreCase(this string text) => text.Split('_', StringSplitOptions.RemoveEmptyEntries);
        public static IEnumerable<string> FromSpaceCase(this string text) => text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        public static string ToPascalCase(this IEnumerable<string> words) =>
            words.ToLower().Select(c => c[0].ToUpper() + c[1..]).ToJoin();
        public static string ToCamelCase(this IEnumerable<string> words) =>
            words.ToLower().Select((c, i) => i == 0 ? c : c[0].ToUpper() + c[1..]).ToJoin();
        public static string ToUnderscoreCase(this IEnumerable<string> words) => words.ToLower().ToJoin("_");
        public static string ToSpaceCase(this IEnumerable<string> words) => words.ToLower().ToJoin(" ");
    }
}
