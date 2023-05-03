namespace Zu1779.GenUtil.Extension.ChainExtension;

using System;
using System.Linq.Expressions;
using System.Reflection;

public static class ChainExtension
{
    /// <summary>
    /// Call an object member like a chain execution
    /// </summary>
    public static T Chain<T>(this T obj, Action<T> action)
    {
        action(obj);
        return obj;
    }
    public static T Chain<T, TOut>(this T obj, Func<T, TOut> func, out TOut output)
    {
        output = func(obj);
        return obj;
    }

    public static TOut ChainRet<T, TOut>(this T obj, Func<T, TOut> func) => func(obj);

    public static T ChainSet<T, TProp>(this T obj, Expression<Func<T, TProp>> property, TProp value)
    {
        PropertyInfo propInfo = (PropertyInfo)(property.Body as MemberExpression).Member;
        propInfo.SetValue(obj, value);
        return obj;
    }

    public static T ChainGet<T, TProp>(this T obj, Expression<Func<T, TProp>> property, out TProp value)
    {
        value = property.Compile()(obj);
        return obj;
    }
}
