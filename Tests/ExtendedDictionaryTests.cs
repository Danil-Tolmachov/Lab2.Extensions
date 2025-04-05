using Lab2.ExtendedDictionary;

namespace Tests;

public class ExtendedDictionaryTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(20)]
    public void Count_Works(int expectedCount)
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>();
        for (int i = 0; i < expectedCount; i++)
        {
            dictionary.Add(i, "test", "test");
        }

        // Act
        var actual = dictionary.Count;

        // Assert
        Assert.Equal(expectedCount, actual);
    }

    [Fact]
    public void Remove_Works()
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>()
        {
            { 1, "foo1", "bar1" },
            { 2, "foo2", "bar2" },
            { 10, "foo10", "bar10" }
        };
        var countBefore = dictionary.Count;

        // Act
        dictionary.Remove(10);

        // Assert
        Assert.Equal(countBefore - 1, dictionary.Count);
    }

    [Fact]
    public void Add_Works()
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>();
        var elements = new List<(int Key, string Value1, string Value2)>()
        {
            new(1, "foo1", "bar1"),
            new(2, "foo2", "bar2"),
            new(10, "foo10", "bar10"),
        };

        // Act
        foreach (var (Key, Value1, Value2) in elements)
        {
            dictionary.Add(Key, Value1, Value2);
        }

        // Assert
        Assert.Equal(elements.Count, dictionary.Count);

        foreach (var (key, value1, value2) in elements)
        {
            Assert.True(dictionary.Any(e => e.Key == key), $"Missing key: {key}");
            Assert.True(dictionary.Any(e => e.Value1 == value1), $"Missing value 1: {value1}");
            Assert.True(dictionary.Any(e => e.Value2 == value2), $"Missing value 2: {value2}");
        }
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(10, true)]
    [InlineData(11, false)]
    public void CheckForExistence_ForKey_Works(int key, bool expected)
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>()
        {
            { 1, "foo1", "bar1" },
            { 2, "foo2", "bar2" },
            { 10, "foo10", "bar10" }
        };

        // Act
        var actual = dictionary.CheckForExistence(key);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("foo1", true)]
    [InlineData("foo2", true)]
    [InlineData("foo10", true)]
    [InlineData("notExisting", false)]
    public void CheckForExistence_ForValue1_Works(string value1, bool expected)
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>()
        {
            { 1, "foo1", "bar1" },
            { 2, "foo2", "bar2" },
            { 10, "foo10", "bar10" }
        };

        // Act
        var actual = dictionary.CheckForExistence(value1, t => t.Value1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("bar1", true)]
    [InlineData("bar2", true)]
    [InlineData("bar10", true)]
    [InlineData("notExisting", false)]
    public void CheckForExistence_ForValue2_Works(string value2, bool expected)
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>()
        {
            { 1, "foo1", "bar1" },
            { 2, "foo2", "bar2" },
            { 10, "foo10", "bar10" }
        };

        // Act
        var actual = dictionary.CheckForExistence(value2, t => t.Value2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Indexing_ForKey_Works()
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>()
        {
            { 1, "foo1", "bar1" },
            { 2, "foo2", "bar2" },
            { 10, "foo10", "bar10" }
        };

        // Act
        var actual = dictionary[10];

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(10, actual.Key);
    }

    [Fact]
    public void Indexing_ForValue1_Works()
    {
        // Arrange
        var searchKey = 'A';
        var dictionary = new ExtendedDictionary<int, char, string>()
        {
            { 1, searchKey, "bar1" },
            { 2, 'B', "bar2" },
            { 10, 'C', "bar10" }
        };

        // Act
        var actual = dictionary[searchKey];

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(searchKey, actual.Value1);
    }

    [Fact]
    public void Indexing_ForValue2_Works()
    {
        // Arrange
        var searchKey = "bar2";
        var dictionary = new ExtendedDictionary<int, char, string>()
        {
            { 1, 'A', "bar1" },
            { 2, 'B', searchKey },
            { 10, 'C', "bar10" }
        };

        // Act
        var actual = dictionary[searchKey];

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(searchKey, actual.Value2);
    }

    [Fact]
    public void IsEnumerable()
    {
        // Arrange
        var dictionary = new ExtendedDictionary<int, string, string>()
        {
            { 1, "foo1", "bar1" },
            { 2, "foo2", "bar2" },
            { 10, "foo10", "bar10" }
        };

        // Act
        var actual = dictionary.AsEnumerable();

        // Assert
        Assert.NotNull(actual);
    }
}
