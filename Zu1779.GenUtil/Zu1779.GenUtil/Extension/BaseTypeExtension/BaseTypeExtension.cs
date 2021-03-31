namespace Zu1779.GenUtil.Extension.BaseTypeExtension
{
    using System;

    public static class CharacterExtension
    {
        /// <summary>
        /// Safely transform to upper a char.
        /// </summary>
        public static char ToUpper(this char character) => char.ToUpper(character);
        /// <summary>
        /// Safely transform to upper a nullable char.
        /// </summary>
        public static char? ToUpper(this char? character) => character.HasValue ? char.ToUpper(character.Value) : (char?)null;
        /// <summary>
        /// Safely transform to lower a char.
        /// </summary>
        public static char ToLower(this char character) => char.ToLower(character);
        /// <summary>
        /// Safely transform to lower a nullable char.
        /// </summary>
        public static char? ToLower(this char? character) => character.HasValue ? char.ToLower(character.Value) : (char?)null;

        public static string Repeat(this char character, int count) => new string(character, count);
    }

    public static class DecimalExtension
    {
        public static long? ToOA(this decimal? value) => value.HasValue ? value.Value.ToOA() : (long?)null;
        public static long ToOA(this decimal value) => decimal.ToOACurrency(value);

        public static decimal? FromOA(this long? value) => value.HasValue ? value.Value.FromOA() : (decimal?)null;
        public static decimal FromOA(this long value) => decimal.FromOACurrency(value);
    }
}
