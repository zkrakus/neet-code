using neetcode.ArraysAndHashing;

namespace Test.ArraysAndHashing;
public class GroupAnagramsTests
{
    [Fact]
    public void GroupAnagrams_WithBasicAnagrams_ReturnsGroupedLists()
    {
        // Arrange
        var input = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };

        // Act
        var result = GroupAnagrams.DoGroupAnagramsWithSort(input);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Contains(result, group => group.Contains("eat") && group.Contains("tea") && group.Contains("ate"));
        Assert.Contains(result, group => group.Contains("tan") && group.Contains("nat"));
        Assert.Contains(result, group => group.Contains("bat"));
    }

    [Fact]
    public void GroupAnagrams_WithNoAnagrams_ReturnsAllSingleGroups()
    {
        var input = new[] { "abc", "def", "ghi" };
        var result = GroupAnagrams.DoGroupAnagramsWithSort(input);

        Assert.Equal(3, result.Count);
        foreach (var word in input)
        {
            Assert.Contains(result, group => group.Count == 1 && group[0] == word);
        }
    }

    [Fact]
    public void GroupAnagrams_WithEmptyArray_ReturnsEmptyList()
    {
        var input = new string[0];
        var result = GroupAnagrams.DoGroupAnagramsWithSort(input);

        Assert.Empty(result);
    }

    [Fact]
    public void GroupAnagrams_WithSingleElement_ReturnsSingleGroup()
    {
        var input = new[] { "solo" };
        var result = GroupAnagrams.DoGroupAnagramsWithSort(input);

        Assert.Single(result);
        Assert.Single(result[0]);
        Assert.Equal("solo", result[0][0]);
    }

    [Fact]
    public void GroupAnagrams_WithDuplicates_GroupsTogether()
    {
        var input = new[] { "abc", "bca", "cab", "abc" };
        var result = GroupAnagrams.DoGroupAnagramsWithSort(input);

        Assert.Single(result.Where(group => group.Contains("abc") && group.Contains("bca") && group.Contains("cab")));
        Assert.Equal(4, result.SelectMany(g => g).Count());
    }
}
