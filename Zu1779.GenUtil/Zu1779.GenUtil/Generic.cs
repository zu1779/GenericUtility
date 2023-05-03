using System;
using System.Linq;
using System.Security.Cryptography;

namespace Zu1779.GenUtil;

public class Generic
{
    private static Random _rng = new Random();

    public static string RandomStringUnsecure(int length = 10)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[_rng.Next(s.Length)]).ToArray());
        return randomString;
    }

    public static string RandomStringSecure(int count = 64)
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(count));
    }
}
