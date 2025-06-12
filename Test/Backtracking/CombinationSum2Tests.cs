using neetcode.Backtracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Backtracking;
public class CombinationSum2Tests
{
    [Fact]
    public void Returns_CorrectCombinations_WithDuplicates()
    {
        var input = new[] { 10, 1, 2, 7, 6, 1, 5 };
        int target = 8;

        var result = CombinationSum2.DoCombinationSum2(input, target);

        var expected = new List<List<int>>
            {
                new() { 1, 1, 6 },
                new() { 1, 2, 5 },
                new() { 1, 7 },
                new() { 2, 6 }
            };

        Assert.Equal(expected.Count, result.Count);
        foreach (var combo in expected)
            Assert.Contains(result, r => EqualLists(r, combo));
    }

    [Fact]
    public void Returns_Empty_WhenNoCombinationMatches()
    {
        var input = new[] { 3, 4, 5 };
        int target = 2;

        var result = CombinationSum2.DoCombinationSum2(input, target);

        Assert.Empty(result);
    }

    [Fact]
    public void Returns_Empty_WhenInputIsEmpty()
    {
        var result = CombinationSum2.DoCombinationSum2(new int[] { }, 5);
        Assert.Empty(result);
    }

    [Fact]
    public void Returns_SingleCombination_IfExactMatch()
    {
        var result = CombinationSum2.DoCombinationSum2(new[] { 5 }, 5);
        Assert.Single(result);
        Assert.Equal(new List<int> { 5 }, result[0]);
    }

    [Fact]
    public void Returns_Empty_WhenTargetIsZero()
    {
        var result = CombinationSum2.DoCombinationSum2(new[] { 1, 2, 3 }, 0);
        Assert.Empty(result);
    }

    private static bool EqualLists(List<int> a, List<int> b)
    {
        if (a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
            if (a[i] != b[i]) return false;
        return true;
    }
}

