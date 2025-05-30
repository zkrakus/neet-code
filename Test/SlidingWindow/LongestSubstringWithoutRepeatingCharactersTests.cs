using neetcode.SlidingWindow;

namespace Test.SlidingWindow;
public class LongestSubstringWithoutRepeatingCharactersTests
{
    public class LongestSubstringTests
    {
        [Theory]
        [InlineData("abcabcbb", 3)]     // "abc"
        [InlineData("bbbbb", 1)]        // "b"
        [InlineData("pwwkew", 3)]       // "wke"
        [InlineData("", 0)]             // empty string
        [InlineData("abcdefg", 7)]      // all unique
        [InlineData("abba", 2)]         // "ab"
        [InlineData("a", 1)]            // single char
        [InlineData("tmmzuxt", 5)]      // "mzuxt"
        [InlineData("dvdf", 3)]         // "vdf"
        [InlineData("abcdeafgh", 8)]    // "bcdeafg"
        public void LengthOfLongestSubstring_ReturnsExpected(string input, int expected)
        {
            int actual = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(input);
            Assert.Equal(expected, actual);
        }
    }
}
