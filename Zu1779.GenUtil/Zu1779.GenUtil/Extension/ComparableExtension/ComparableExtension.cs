namespace Zu1779.GenUtil.Extension.ComparableExtension
{
    using System;

    public static class ComparableExtension
    {
        /// <summary>
        /// Return value if lesser or equal max, otherwise return max.
        /// </summary>
        public static T MaxCap<T>(this T value, T max) where T : IComparable => value.CompareTo(max) > 0 ? max : value;
        /// <summary>
        /// Return value if greater or equal min, otherwise return min.
        /// </summary>
        public static T MinCap<T>(this T value, T min) where T : IComparable => value.CompareTo(min) < 0 ? min : value;
        /// <summary>
        /// Return value if inside the range of min and max, otherwise return min if value is lesser than min or max if value is greater than max.
        /// </summary>
        public static T Cap<T>(this T value, T min, T max) where T : IComparable => value.MinCap(min).MaxCap(max);
    }
}
