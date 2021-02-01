namespace Zu1779.GenUtil.Extension.MiscExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Zu1779.GenUtil.Extension.ObjectExtension;

    public static class MiscExtension
    {
        public static TResult SelectObj<T, TResult>(this T obj, Func<T, TResult> prj) => prj(obj);

        public static T Dump<T>(this T obj, string header = "", string footer = "")
        {
            string output = string.Empty;
            if (!header.IsNullOrDefault()) output += $"{header}: ";
            output += obj.ToString();
            if (!footer.IsNullOrDefault()) output += footer;
            Console.WriteLine(output);
            return obj;
        }

        public static T DumpObj<T>(this T obj, string header = "", string footer = "")
        {
            var output = new List<string>();
            if (!header.IsNullOrDefault()) output.Add($"{header}:");
            output.AddRange(typeof(T).GetProperties().Select(c => $"{c.Name} = {c.GetValue(obj)}"));
            if (!footer.IsNullOrDefault()) output.Add(footer);
            output.DumpEnumerable();
            return obj;
        }

        public static IEnumerable<T> DumpEnumerable<T>(this IEnumerable<T> enumerable, string header = "")
        {
            if (!header.IsNullOrDefault()) header.Dump();
            foreach (var tuple in enumerable.Select((item, index) => (item, index)))
            {
                $"[{tuple.index}] {tuple.item}".Dump();
            }
            return enumerable;
        }

        public static string Singularize(this string word, params string[] except) =>
            word.EndsWith('s') && !except.Contains(word) ? word[0..^1] : word;
        public static IEnumerable<string> Singularize(this IEnumerable<string> words, params string[] exept) =>
            words.Select(c => c.EndsWith('s') && !exept.Contains(c, GenCompare.StringCI) ? c[0..^1] : c);
    }
}
