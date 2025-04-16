using neetcode.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ArraysAndHashing;
public class TwoSumTests
{
    [Fact]
    public void FindsCorrectIndices_NormalCase()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        var result = TwoSum.Sum(nums, target);
        Assert.Equal(new[] { 0, 1 }, result.OrderBy(x => x));
    }

    [Fact]
    public void HandlesNegativeNumbers()
    {
        int[] nums = { -3, 4, 3, 90 };
        int target = 0;
        var result = TwoSum.Sum(nums, target);
        Assert.Equal(new[] { 0, 2 }, result.OrderBy(x => x));
    }

    [Fact]
    public void HandlesMultipleSolutions_ReturnsAnyValidOne()
    {
        int[] nums = { 3, 2, 4 };
        int target = 6;
        var result = TwoSum.Sum(nums, target);
        Assert.Equal(new[] { 1, 2 }, result.OrderBy(x => x));
    }

    [Fact]
    public void HandlesSameElementTwice()
    {
        int[] nums = { 3, 3 };
        int target = 6;
        var result = TwoSum.Sum(nums, target);
        Assert.Equal(new[] { 0, 1 }, result.OrderBy(x => x));
    }

    [Fact]
    public void WorksWithZeros()
    {
        int[] nums = { 0, 4, 3, 0 };
        int target = 0;
        var result = TwoSum.Sum(nums, target);
        Assert.Equal(new[] { 0, 3 }, result.OrderBy(x => x));
    }

    [Fact]
    public void LargeInput_ReturnsCorrectResult()
    {
        int[] nums = Enumerable.Range(1, 10000).ToArray();
        int target = 19999;
        var result = TwoSum.Sum(nums, target);
        Assert.Equal(new[] { 9998, 9999 }, result.OrderBy(x => x));
    }

    [Fact]
    public void ThrowsOrReturnsEmpty_WhenNoSolution()
    {
        int[] nums = { 1, 2, 3 };
        int target = 7;

        // Option A: if you throw
        Assert.Throws<InvalidOperationException>(() => TwoSum.Sum(nums, target));

        // OR Option B: if you return an empty array
        // Assert.Empty(TwoSum.Sum(nums, target));
    }
}
