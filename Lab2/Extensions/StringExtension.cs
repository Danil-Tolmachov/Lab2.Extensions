using System.Text.RegularExpressions;

namespace Lab2.Extensions;

public static class StringExtension
{
    public static string CustomReverse(this string str)
    {
        return string.Join("", str.AsEnumerable().Reverse());
    }

    public static int CustomCount(this string str, string matchTerm)
    {
        return Regex.Count(str, matchTerm);
    }
}
