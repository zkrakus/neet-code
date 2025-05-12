using neetcode.Backtracking;

namespace Test.Backtracking;
public class CombinationSumTests
{
    [Fact]
    public void Test_Example1()
    {
        var nums = new[] { 2, 5, 6, 9 };
        var target = 9;
        var result = CombinationSum.DoCombinationSum(nums, target);

        Assert.Contains(result, r => new HashSet<int>(r).SetEquals(new[] { 2, 2, 5 }));
        Assert.Contains(result, r => new HashSet<int>(r).SetEquals(new[] { 9 }));
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Test_Example2()
    {
        var nums = new[] { 3, 4, 5 };
        var target = 16;
        var result = CombinationSum.DoCombinationSum(nums, target);

        var expected = new List<List<int>> {
            new List<int> {3,3,3,3,4},
            new List<int> {3,3,5,5},
            new List<int> {4,4,4,4},
            new List<int> {3,4,4,5}
        };

        foreach (var combo in expected)
        {
            Assert.Contains(result, r => new HashSet<int>(r).SetEquals(combo));
        }

        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void Test_Example3()
    {
        var nums = new[] { 3 };
        var target = 5;
        var result = CombinationSum.DoCombinationSum(nums, target);
        Assert.Empty(result);
    }
}