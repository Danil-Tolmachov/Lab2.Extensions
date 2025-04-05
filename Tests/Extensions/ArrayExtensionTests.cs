using Lab2.Extensions;

namespace Tests.Extensions;

public class ArrayExtensionTests
{
    [Theory]
    [InlineData(new[] { 1 }, 1, 1)]
    [InlineData(new[] { 1, 2, 3 }, 1, 1)]
    [InlineData(new[] { 2, 2, 2 }, 2, 3)]
    public void Count_IntArray_Works(int[] array, int match, int expectedCount)
    {
        // Act
        var actual = array.CustomCount(match);

        // Assert
        Assert.Equal(expectedCount, actual);
    }

    [Theory]
    [InlineData(new[] { 'A' }, 'A', 1)]
    [InlineData(new[] { 'A', 'B', 'C' }, 'A', 1)]
    [InlineData(new[] { 'B', 'B', 'B' }, 'B', 3)]
    public void Count_CharArray_Works(char[] array, char match, int expectedCount)
    {
        // Act
        var actual = array.CustomCount(match);

        // Assert
        Assert.Equal(expectedCount, actual);
    }

    [Theory]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 1, 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 2, 3, 3 }, new[] { 1, 2, 3 })]
    public void Distinct_IntArray_Works(int[] initial, int[] expected)
    {
        // Act
        var actual = initial.CustomDistinct();

        // Assert
        Assert.Equivalent(expected, actual);
    }


    [Theory]
    [InlineData(new[] { 'A' }, new[] { 'A' })]
    [InlineData(new[] { 'A', 'A' }, new[] { 'A' })]
    [InlineData(new[] { 'A', 'B', 'C', 'C' }, new[] { 'A', 'B', 'C' })]
    public void Distinct_CharArray_Works(char[] initial, char[] expected)
    {
        // Act
        var actual = initial.CustomDistinct();

        // Assert
        Assert.Equivalent(expected, actual);
    }
}
