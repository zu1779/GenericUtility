using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zu1779.GenUtil.Extension.EnumerableExtension
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Join an enumerable of string by an optional separator.
        /// </summary>
        /// <param name="words">Strings to join.</param>
        /// <param name="separator">Separator to use to join strings.</param>
        /// <returns>Joined string.</returns>
        public static string ToJoin(this IEnumerable<string> words, string separator = "") => string.Join(separator, words);

        public static IEnumerable<string> ToLower(this IEnumerable<string> words) => words.Select(c => c.ToLower());
        public static IEnumerable<string> ToUpper(this IEnumerable<string> words) => words.Select(c => c.ToUpper());
    }
}
