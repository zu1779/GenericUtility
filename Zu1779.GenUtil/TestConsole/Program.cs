using System;

using Zu1779.GenUtil.Extension.MethodExtension;
using Zu1779.GenUtil.Extension.ObjectExtension;

namespace TestConsole;

public class Program
{
    public static void Main()
    {
        new Program().Run();
    }

    public void Run()
    {
        //var typeName = GetTypeName<string>();
        var typeName = this.CallGenericWithType<Program, string>(nameof(this.GetTypeName), typeof(string), null).CheckNotNull();
        Console.WriteLine($"type name is: {typeName}");
    }

    public string GetTypeName<T>() => typeof(T).Name;
}
