using System.Collections;

namespace Lab2.ExtendedDictionary;

public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
    where T : notnull
{
    private Dictionary<T, ExtendedDictionaryElement<T, U, V>> Dictionary { get; set; } = new();

    public int Count { get => Dictionary.Count; } 

    public void Remove(T key)
    {
        Dictionary.Remove(key);
    }

    public void Add(T key, U value1, V value2)
    {
        var element = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);
        Dictionary.Add(key, element);
    }

    public bool CheckForExistence(T key)
    {
        return Dictionary.TryGetValue(key, out _);
    }

    public bool CheckForExistence<VType>(VType value, Func<ExtendedDictionaryElement<T, U, V>, VType> propertySelector)
        where VType : U, V
    {
        return Dictionary.Values.FirstOrDefault(v => EqualityComparer<VType>.Default.Equals(propertySelector(v), value))
            is not null;
    }

    public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
    {
        var enumerator = Dictionary.Select(d => d.Value)
                                   .GetEnumerator();
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public ExtendedDictionaryElement<T, U, V> this[T i]
    {
        get
        {
            return Dictionary[i];
        }
        set
        {
            if (!value.Key.Equals(i))
            {
                throw new InvalidOperationException("Invalid attempt to set element with different key value.");
            }

            Dictionary[i] = value;
        }
    }

    public ExtendedDictionaryElement<T, U, V> this[U i]
    {
        get
        {
            return Dictionary.Values.First(v => v.Value1?.Equals(i) ?? false);
        }
    }

    public ExtendedDictionaryElement<T, U, V> this[V i]
    {
        get
        {
            return Dictionary.Values.First(v => v.Value2?.Equals(i) ?? false);
        }
    }
}
