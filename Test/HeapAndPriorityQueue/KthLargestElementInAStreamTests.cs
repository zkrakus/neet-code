using neetcode.HeapAndPriorityQueue;

namespace Test.HeapAndPriorityQueue;


public class KthLargestElementInAStreamTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithKthLargest()
    {
        var stream = new KthLargestElementInAStream(3, new[] { 1, 2, 3, 3 });
        var result = stream.Add(3); // Adding same as existing

        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_ShouldReturnUpdatedKthLargest()
    {
        var stream = new KthLargestElementInAStream(3, new[] { 1, 2, 3 });

        Assert.Equal(2, stream.Add(3));  // Heap: [2,3,3] → 2
        Assert.Equal(3, stream.Add(5));  // Heap: [3,3,5] → 3
        Assert.Equal(3, stream.Add(6));  // Heap: [3,5,6] → 3
        Assert.Equal(5, stream.Add(7));  // Heap: [5,6,7] → 5
        Assert.Equal(6, stream.Add(8));  // Heap: [6,7,8] → 6
    }

    [Fact]
    public void Stream_ShouldHandleNegativeValues()
    {
        var stream = new KthLargestElementInAStream(2, new[] { -10, -20, -5 });

        Assert.Equal(-10, stream.Add(-15)); // Top 2: [-10, -5] → kth = -10
        Assert.Equal(-5, stream.Add(0));    // Top 2: [0, -5] → kth = -5
    }

    [Fact]
    public void Stream_ShouldHandleEmptyInitialArray()
    {
        var stream = new KthLargestElementInAStream(1, Array.Empty<int>());

        Assert.Equal(10, stream.Add(10));
        Assert.Equal(20, stream.Add(20));
    }

    [Fact]
    public void Add_ShouldPreserveTopKElementsOnly()
    {
        var stream = new KthLargestElementInAStream(2, new[] { 4, 5, 8, 2 });

        Assert.Equal(5, stream.Add(3));  // [5,4]
        Assert.Equal(5, stream.Add(5));  // [5,5]
        Assert.Equal(8, stream.Add(10)); // [10,8]
    }
}
