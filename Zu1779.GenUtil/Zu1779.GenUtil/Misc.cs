namespace Zu1779.GenUtil
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

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
        public int GetHashCode(T obj) => _hash(obj);
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
