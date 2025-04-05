using Lab2.Extensions;

namespace Tests.Extensions;

public class StringExtensionTests
{
    [Theory]
    [InlineData("too many word here", "ereh drow ynam oot")]
    public void Reverse_Works(string input, string expected)
    {
        // Act 
        var actual = input.CustomReverse();
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("too many word here", "o", 3)]
    public void Count_Works(string input, string match, int expected)
    {
        // Act 
        var actual = input.CustomCount(match);

        // Assert
        Assert.Equal(expected, actual);
    }
}
