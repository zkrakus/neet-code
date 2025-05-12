using neetcode.TwoPointers;

namespace Test.TwoPointers;
public class TwoIntegerSum2Tests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
    [InlineData(new int[] { -3, -1, 0, 2, 4 }, 1, new int[] { 1, 5 })]
    [InlineData(new int[] { 5, 25, 75 }, 100, new int[] { 2, 3 })]
    [InlineData(new int[] { 1, 3, 4, 5, 7, 10, 11 }, 9, new int[] { 3, 4 })]
    public void ReturnsCorrectIndices(int[] numbers, int target, int[] expected)
    {
        var result = TwoIntegerSum2.TwoSum(numbers, target);
        Assert.Equal(expected, result);
    }
}
