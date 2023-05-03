using System;
using System.Drawing;
using System.Text.Json;

namespace Zu1779.GenUtil;

public static class MyExtensions
{
    public static void SetDomainData<T>(string dataKey, T? data)
    {
        string strJson = JsonSerializer.Serialize(data);
        AppDomain.CurrentDomain.SetData(dataKey, strJson);
    }

    public static T? GetDomainData<T>(string dataKey)
    {
        string? strJson = (string?)AppDomain.CurrentDomain.GetData(dataKey);
        return strJson == null ? default : (T?)JsonSerializer.Deserialize<T>(strJson);
    }
}
