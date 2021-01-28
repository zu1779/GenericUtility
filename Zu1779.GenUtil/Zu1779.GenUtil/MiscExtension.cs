namespace Zu1779.GenUtil
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class CharacterExtension
    {
        /// <summary>
        /// Safely transform to upper a char.
        /// </summary>
        public static char ToUpper(this char character) => char.ToUpper(character);
        /// <summary>
        /// Safely transform to upper a nullable char.
        /// </summary>
        public static char? ToUpper(this char? character) => character.HasValue ? char.ToUpper(character.Value) : null;
        /// <summary>
        /// Safely transform to lower a char.
        /// </summary>
        public static char ToLower(this char character) => char.ToLower(character);
        /// <summary>
        /// Safely transform to lower a nullable char.
        /// </summary>
        public static char? ToLower(this char? character) => character.HasValue ? char.ToLower(character.Value) : null;
    }

    public static class IntExtension
    {
        public static int MaxCap(this int value, int max) => value <= max ? value : max;
        public static int MinCap(this int value, int min) => value >= min ? value : min;
        public static int Cap(this int value, int min, int max) => value.MinCap(min).MaxCap(max);
    }

    public static class StringEnumExtension
    {
        /// <summary>
        /// Join an enumerable of string by an optional separator.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToJoin(this IEnumerable<string> words, string separator = "") => string.Join(separator, words);

        public static IEnumerable<string> ToLower(this IEnumerable<string> words) => words.Select(c => c.ToLower());
        public static IEnumerable<string> ToUpper(this IEnumerable<string> words) => words.Select(c => c.ToUpper());
    }

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
        public static string ToJoinCase(this IEnumerable<string> words) => words.ToLower().ToJoin(" ");
    }

    public static class FileSystemExtension
    {
        /// <summary>
        /// Get the file name without extension.
        /// </summary>
        public static string NoExtension(this FileInfo fileInfo) => Path.GetFileNameWithoutExtension(fileInfo.Name);

        #region ToDecide
        //public static IEnumerable<FileSystemInfo> EnumAll(this FileSystemInfo fsi, Predicate<DirectoryInfo> dirFilter = null)
        //{
        //	try
        //	{
        //		var dir = fsi.AsDirectory();
        //		if (dirFilter == null || dirFilter(dir))
        //		{
        //			var items = dir.EnumerateFileSystemInfos();
        //			foreach (var item in items.ToArray())
        //			{
        //				if (item.IsDirectory()) items = items.Union(item.EnumAll(dirFilter));
        //			}
        //			return items;
        //		}
        //		else return Enumerable.Empty<FileSystemInfo>();
        //	}
        //	catch (Exception ex)
        //	{
        //		ex.Dump();
        //		return Enumerable.Empty<FileSystemInfo>();
        //	}
        //}
        //public static IEnumerable<FileInfo> EnumAllFiles(this DirectoryInfo dirInfo)
        //{
        //	try
        //	{
        //		var files = dirInfo.EnumerateFiles();
        //		var dirs = dirInfo.EnumerateDirectories();
        //		foreach (var dir in dirs) files = files.Union(dir.EnumAllFiles());
        //		return files;
        //	}
        //	catch (Exception ex)
        //	{
        //		ex.Message.Dump();
        //		return Enumerable.Empty<FileInfo>();
        //	}
        //}

        //public static bool IsFile(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.Archive);
        //public static bool IsDirectory(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.Directory);
        //public static bool IsSystem(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.System);
        //public static bool IsHidden(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.Hidden);

        //public static DirectoryInfo AsDirectory(this FileSystemInfo fsi) => (DirectoryInfo)fsi;

        //public static bool CanReadData(this DirectoryInfo dirInfo) => dirInfo.CanDo(FileSystemRights.ReadData);
        //private static bool CanDo(this DirectoryInfo dirInfo, FileSystemRights right)
        //{
        //	try
        //	{
        //		var rules = dirInfo.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
        //		var canDo = rules.Cast<FileSystemAccessRule>().Any(c => c.FileSystemRights.HasFlag(right) && c.AccessControlType == AccessControlType.Allow);
        //		var cannotDo = rules.Cast<FileSystemAccessRule>().Any(c => c.FileSystemRights.HasFlag(right) && c.AccessControlType == AccessControlType.Deny);
        //		return canDo && !cannotDo;
        //	}
        //	catch (Exception ex)
        //	{
        //		return false;
        //	}
        //}
        #endregion
    }

    public static class MiscExtension
    {
        public static string Singularize(this string word, params string[] except) =>
            word.EndsWith('s') && !except.Contains(word) ? word[0..^1] : word;
        public static IEnumerable<string> Singularize(this IEnumerable<string> words, params string[] exept) =>
            words.Select(c => c.EndsWith('s') && !exept.Contains(c, GenCompare.StringCI) ? c[0..^1] : c);

        public static TResult SelectObj<T, TResult>(this T obj, Func<T, TResult> prj) => prj(obj);
    }

    public class GenCompare<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comp;
        private readonly Func<T, int> _hash;

        public GenCompare(Func<T, T, bool> comp, Func<T, int> hash)
        {
            _comp = comp;
            _hash = hash;
        }

        public bool Equals(T x, T y) => _comp(x, y);
        public int GetHashCode([DisallowNull] T obj) => _hash(obj);
    }
    public class GenCompare
    {
        public static IEqualityComparer<TComp> Gen<TComp>(Func<TComp, TComp, bool> comp, Func<TComp, int> hash) =>
            new GenCompare<TComp>(comp, hash);
        public static IEqualityComparer<string> String(bool ignoreCase = true) =>
            Gen((string x, string y) => string.Compare(x, y, ignoreCase) == 0, c => c.GetHashCode());
        public static IEqualityComparer<string> StringCS => String(false);
        public static IEqualityComparer<string> StringCI => String(true);
    }
}
