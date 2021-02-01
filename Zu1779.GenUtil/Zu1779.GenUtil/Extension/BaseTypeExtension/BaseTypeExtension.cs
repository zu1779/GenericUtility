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
        public static char? ToUpper(this char? character) => character.HasValue ? char.ToUpper(character.Value) : null;
        /// <summary>
        /// Safely transform to lower a char.
        /// </summary>
        public static char ToLower(this char character) => char.ToLower(character);
        /// <summary>
        /// Safely transform to lower a nullable char.
        /// </summary>
        public static char? ToLower(this char? character) => character.HasValue ? char.ToLower(character.Value) : null;

        public static string Repeat(this char character, int count) => new string(character, count);
    }
}
