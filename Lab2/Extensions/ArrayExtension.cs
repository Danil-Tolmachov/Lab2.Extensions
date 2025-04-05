namespace Lab2.Extensions;

public static class ArrayExtension
{
    public static int CustomCount<T>(this T[] arr, T match)
        where T : notnull
    {
        return arr.Count(x => x.Equals(match));
    }

    public static T[] CustomDistinct<T>(this T[] arr)
        where T : notnull
    {
        return arr.Distinct().ToArray();
    }
}
