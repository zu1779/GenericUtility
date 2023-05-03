using System;
using System.Linq.Expressions;

namespace Zu1779.GenUtil.Extension.MethodExtension;

public static class MethodExtension
{
    public static TReturn? CallGenericWithType<T, TReturn>(this T target, string methodName, Type typeArgument, object[]? arguments)
    {
        var method = typeof(T).GetMethod(methodName);
        if (method == null || !method.IsGenericMethod)
            throw new ArgumentException("Invalid method name");

        var genericMethod = method.MakeGenericMethod(typeArgument);
        var result = genericMethod.Invoke(target, arguments);
        return (TReturn?)result;
    }
}
