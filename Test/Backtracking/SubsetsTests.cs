using neetcode.Backtracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Backtracking;
public class SubsetsTests
{
    private static List<List<int>> Normalize(List<List<int>> subsets)
    {
        return subsets
            .Select(s => s.OrderBy(x => x).ToList())
            .OrderBy(s => s.Count)
            .ThenBy(s => string.Join(",", s))
            .ToList();
    }

    [Fact]
    public void Test_Subsets_WithThreeElements()
    {
        var nums = new[] { 1, 2, 3 };
        var result = Subsets.FindSubsets(nums);

        var expected = new List<List<int>>
        {
            new(), new() { 1 }, new() { 2 }, new() { 3 },
            new() { 1, 2 }, new() { 1, 3 }, new() { 2, 3 },
            new() { 1, 2, 3 }
        };

        Assert.Equal(Normalize(expected), Normalize(result));
    }

    [Fact]
    public void Test_Subsets_WithOneElement()
    {
        var nums = new[] { 7 };
        var result = Subsets.FindSubsets(nums);

        var expected = new List<List<int>>
        {
            new(), new() { 7 }
        };

        Assert.Equal(Normalize(expected), Normalize(result));
    }

    [Fact]
    public void Test_Subsets_WithTwoElements()
    {
        var nums = new[] { 0, 1 };
        var result = Subsets.FindSubsets(nums);

        var expected = new List<List<int>>
        {
            new(), new() { 0 }, new() { 1 }, new() { 0, 1 }
        };

        Assert.Equal(Normalize(expected), Normalize(result));
    }

    [Fact]
    public void Test_Subsets_WithEmptyArray()
    {
        var nums = new int[] { };
        var result = Subsets.FindSubsets(nums);

        var expected = new List<List<int>> { new() };

        Assert.Equal(Normalize(expected), Normalize(result));
    }
}