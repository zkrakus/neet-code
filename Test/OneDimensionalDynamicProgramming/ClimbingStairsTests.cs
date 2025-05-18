using neetcode.OneDimensionalDynamicProgramming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.OneDimensionalDynamicProgramming;
public class ClimbingStairsTests
{
    [Theory]
    [InlineData(1, 1)]   // Only 1 way: 1
    [InlineData(2, 2)]   // 1+1, 2
    [InlineData(3, 3)]   // 1+1+1, 1+2, 2+1
    [InlineData(4, 5)]   // Fibonacci-style
    [InlineData(5, 8)]
    [InlineData(6, 13)]
    public void ClimbStairsBrute_ReturnsExpectedWays(int n, int expectedWays)
    {
        // Act
        int actual = ClimbingStairs.ClimbStairsBrute(n);

        // Assert with helpful failure message
        Assert.True(
            actual == expectedWays,
            $"Failed for n={n}: Expected {expectedWays}, but got {actual}"
        );
    }

    [Fact]
    public void ClimbStairsBrute_ZeroSteps_ReturnsZero()
    {
        int result = ClimbingStairs.ClimbStairsBrute(0);
        Assert.True(result == 0, $"Expected 0 for n=0, but got {result}");
    }

    [Fact]
    public void ClimbStairsBrute_NegativeSteps_ReturnsZero()
    {
        int result = ClimbingStairs.ClimbStairsBrute(-1);
        Assert.True(result == 0, $"Expected 0 for n=-1, but got {result}");
    }
}
