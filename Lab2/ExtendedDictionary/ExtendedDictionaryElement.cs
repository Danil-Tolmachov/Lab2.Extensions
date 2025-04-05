namespace Lab2.ExtendedDictionary;

public class ExtendedDictionaryElement<T, U, V>(T key, U value1, V value2)
{
    public T Key { get; init; } = key;

    public U Value1 { get; set; } = value1;

    public V Value2 { get; set; } = value2;
}
