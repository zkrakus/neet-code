using neetcode.HeapAndPriorityQueue;

namespace Test.HeapAndPriorityQueue;
public class LastStoneWeightTests
{
    [Fact]
    public void ShouldReturnCorrectWeight_WhenStonesReduceToOne()
    {
        int[] stones = { 2, 3, 6, 2, 4 };
        int result = LastStoneWeight.FindLastStoneWeight(stones);
        Assert.Equal(1, result);
    }

    [Fact]
    public void ShouldReturnOne_WhenTwoStonesAreUnequal()
    {
        int[] stones = { 1, 2 };
        int result = LastStoneWeight.FindLastStoneWeight(stones);
        Assert.Equal(1, result);
    }

    [Fact]
    public void ShouldReturnZero_WhenTwoStonesAreEqual()
    {
        int[] stones = { 5, 5 };
        int result = LastStoneWeight.FindLastStoneWeight(stones);
        Assert.Equal(0, result);
    }

    [Fact]
    public void ShouldReturnCorrectValue_WithSingleStone()
    {
        int[] stones = { 7 };
        int result = LastStoneWeight.FindLastStoneWeight(stones);
        Assert.Equal(7, result);
    }

    [Fact]
    public void ShouldReturnZero_WhenNoStones()
    {
        int[] stones = { };
        int result = LastStoneWeight.FindLastStoneWeight(stones);
        Assert.Equal(0, result);
    }

    [Fact]
    public void ShouldHandleMultipleReductions()
    {
        int[] stones = { 10, 4, 2, 10 };
        int result = LastStoneWeight.FindLastStoneWeight(stones);
        Assert.Equal(2, result);
    }
}
