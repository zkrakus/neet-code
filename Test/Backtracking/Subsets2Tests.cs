using neetcode.Backtracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Backtracking;
public class Subsets2Tests
{
    [Fact]
    public void SubsetsWithDup_ReturnsEmptySubset_WhenInputIsEmpty()
    {
        var result = Subsets2.SubsetsWithDup(new int[] { });

        Assert.Single(result);
        Assert.Contains(result, r => r.Count == 0);
    }

    [Fact]
    public void SubsetsWithDup_HandlesSingleElement()
    {
        var result = Subsets2.SubsetsWithDup(new[] { 1 });

        var expected = new List<List<int>>
            {
                new List<int>(),       // []
                new List<int>{1},      // [1]
            };

        Assert.Equal(expected.Count, result.Count);
        Assert.All(expected, subset => Assert.Contains(result, r => r.SequenceEqual(subset)));
    }

    [Fact]
    public void SubsetsWithDup_HandlesTwoDistinctElements()
    {
        var result = Subsets2.SubsetsWithDup(new[] { 1, 2 });

        var expected = new List<List<int>>
            {
                new List<int>(),       // []
                new List<int>{1},      // [1]
                new List<int>{2},      // [2]
                new List<int>{1,2},    // [1,2]
            };

        Assert.Equal(expected.Count, result.Count);
        Assert.All(expected, subset => Assert.Contains(result, r => r.SequenceEqual(subset)));
    }

    [Fact]
    public void SubsetsWithDup_HandlesDuplicatesCorrectly()
    {
        var result = Subsets2.SubsetsWithDup(new[] { 1, 2, 2 });

        var expected = new List<List<int>>
            {
                new List<int>(),       // []
                new List<int>{1},      // [1]
                new List<int>{2},      // [2]
                new List<int>{1,2},    // [1,2]
                new List<int>{2,2},    // [2,2]
                new List<int>{1,2,2},  // [1,2,2]
            };

        Assert.Equal(expected.Count, result.Count);
        Assert.All(expected, subset => Assert.Contains(result, r => r.SequenceEqual(subset)));
    }

    [Fact]
    public void SubsetsWithDup_HandlesNullInput()
    {
        var result = Subsets2.SubsetsWithDup(null);

        Assert.Empty(result);
    }
}
