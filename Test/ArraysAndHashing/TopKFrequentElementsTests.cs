using neetcode.ArraysAndHashing;

namespace Test.ArraysAndHashing;
public class TopKFrequentElementsTests
{
    [Fact]
    public void TopKFrequent_BasicCase_ReturnsMostFrequent()
    {
        var nums = new[] { 1, 1, 1, 2, 2, 3 };
        int k = 2;

        var result = TopKFrequentElements.TopKFrequentMinHeap(nums, k);

        Assert.Equal(k, result.Length);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void TopKFrequent_AllElementsEqualFrequency_ReturnsAnyK()
    {
        var nums = new[] { 4, 5, 6, 7 };
        int k = 2;

        var result = TopKFrequentElements.TopKFrequentMinHeap(nums, k);

        Assert.Equal(k, result.Length);
        Assert.All(result, val => Assert.Contains(val, nums));
    }

    [Fact]
    public void TopKFrequent_SingleElementRepeated_ReturnsThatElement()
    {
        var nums = new[] { 9, 9, 9, 9 };
        int k = 1;

        var result = TopKFrequentElements.TopKFrequentMinHeap(nums, k);

        Assert.Single(result);
        Assert.Equal(9, result[0]);
    }

    [Fact]
    public void TopKFrequent_KEqualsNumberOfUniques_ReturnsAll()
    {
        var nums = new[] { 8, 9, 10 };
        int k = 3;

        var result = TopKFrequentElements.TopKFrequentMinHeap(nums, k);

        Assert.Equal(3, result.Length);
        Assert.Contains(8, result);
        Assert.Contains(9, result);
        Assert.Contains(10, result);
    }

    [Fact]
    public void TopKFrequent_KIsZero_ReturnsEmpty()
    {
        var nums = new[] { 1, 2, 3, 4 };
        int k = 0;

        var result = TopKFrequentElements.TopKFrequentMinHeap(nums, k);

        Assert.Empty(result);
    }
}
