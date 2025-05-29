using neetcode.ArraysAndHashing;

namespace Test.ArraysAndHashing;
public class ProductExceptSelfTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 4, 6 }, new int[] { 48, 24, 12, 8 })]
    [InlineData(new int[] { -1, 0, 1, 2, 3 }, new int[] { 0, -6, 0, 0, 0 })]
    [InlineData(new int[] { 2, 3, 4, 5 }, new int[] { 60, 40, 30, 24 })]
    [InlineData(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
    [InlineData(new int[] { 0, 0 }, new int[] { 0, 0 })]
    [InlineData(new int[] { 1, 0 }, new int[] { 0, 1 })]
    public void GetProductExceptSelf_ReturnsExpected(int[] input, int[] expected)
    {
        var result = ProductExceptSelf.GetProductExceptSelf(input);
        Assert.Equal(expected, result);
    }
}