using neetcode.ArraysAndHashing;

namespace Test.ArraysAndHashing;
public class ScoreOfStringTests
{
    [Theory]
    [InlineData(null, 0)]              // null string → 0
    [InlineData("", 0)]                // empty string → 0
    [InlineData("a", 0)]               // single character → 0
    [InlineData("ab", 1)]              // |'b' - 'a'| = 1
    [InlineData("abc", 2)]             // |b-a| + |c-b| = 1 + 1 = 2
    [InlineData("ace", 4)]             // |c-a| + |e-c| = 2 + 2 = 4
    [InlineData("az", 25)]             // |z-a| = 25
    [InlineData("za", 25)]             // |a-z| = 25
    [InlineData("aaa", 0)]             // same letters → 0
    [InlineData("abcdz", 25)]          // |b-a|+|c-b|+|d-c|+|z-d| = 1+1+1+22 = 25
    public void ScoreOfString_ReturnsExpected(string input, int expected)
    {
        var result = ScoreOfString(input);
        Assert.Equal(expected, result);
    }

    // Direct call to your static method
    private static int ScoreOfString(string s) =>
        ScoreOfAString.ScoreOfString(s);
}