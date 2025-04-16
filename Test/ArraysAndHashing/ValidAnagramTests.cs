using neetcode.ArraysAndHashing;

namespace Test.ArraysAndHashing;

public class ValidAnagramTests
{
    [Theory]
    [InlineData("listen", "silent", true)]  // Valid anagrams
    [InlineData("rat", "car", false)]      // Different characters
    [InlineData("aabbcc", "ccbbaa", true)] // Same characters, different order
    [InlineData("", "", true)]             // Empty strings
    [InlineData("hello", "helloo", false)] // Different lengths
    [InlineData("anagram ", "nagaram", false)] // Extra spaces
    [InlineData("Listen", "Silent", false)]    // Case sensitivity
    [InlineData("aabbcc", "abc", false)] // Same characters, different counts
    [InlineData("aabb", "aaab", false)] // Same characters, different counts, same length
    public void IsAnagram_ShouldReturnExpectedResult(string s, string t, bool expected)
    {
        // Act
        bool result = ValidAnagram.IsAnagram1(s, t);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("listen", "silent", true)]  // Valid anagrams
    [InlineData("rat", "car", false)]      // Different characters
    [InlineData("aabbcc", "ccbbaa", true)] // Same characters, different order
    [InlineData("", "", true)]             // Empty strings
    [InlineData("hello", "helloo", false)] // Different lengths
    [InlineData("anagram ", "nagaram", false)] // Extra spaces
    [InlineData("Listen", "Silent", false)]    // Case sensitivity
    [InlineData("aabbcc", "abc", false)] // Same characters, different counts
    [InlineData("aabb", "aaab", false)] // Same characters, different counts, same length
    public void IsAnagram2_ShouldReturnExpectedResult(string s, string t, bool expected)
    {
        // Act
        bool result = ValidAnagram.IsAnagram2(s, t);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("listen", "silent", true)]  // Valid anagrams
    [InlineData("rat", "car", false)]      // Different characters
    [InlineData("aabbcc", "ccbbaa", true)] // Same characters, different order
    [InlineData("", "", true)]             // Empty strings
    [InlineData("hello", "helloo", false)] // Different lengths
    [InlineData("anagram ", "nagaram", false)] // Extra spaces
    [InlineData("Listen", "Silent", false)]    // Case sensitivity
    [InlineData("aabbcc", "abc", false)] // Same characters, different counts
    [InlineData("aabb", "aaab", false)] // Same characters, different counts, same length
    public void IsAnagram3_ShouldReturnExpectedResult(string s, string t, bool expected)
    {
        // Act
        bool result = ValidAnagram.IsAnagram3(s, t);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("listen", "silent", true)]  // Valid anagrams
    [InlineData("rat", "car", false)]      // Different characters
    [InlineData("aabbcc", "ccbbaa", true)] // Same characters, different order
    [InlineData("", "", true)]             // Empty strings
    [InlineData("hello", "helloo", false)] // Different lengths
    [InlineData("anagram ", "nagaram", false)] // Extra spaces
    [InlineData("Listen", "Silent", false)]    // Case sensitivity
    [InlineData("aabbcc", "abc", false)] // Same characters, different counts
    [InlineData("aabb", "aaab", false)] // Same characters, different counts, same length
    public void IsAnagram4_ShouldReturnExpectedResult(string s, string t, bool expected)
    {
        // Act
        bool result = ValidAnagram.IsAnagram4(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
}
