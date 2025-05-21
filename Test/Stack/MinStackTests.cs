using neetcode.Stack;

namespace Test.Stack;
public class MinStackTests
{
    [Fact]
    public void PushPopTopGetMin_SingleElement()
    {
        var stack = new MinStack();
        stack.Push(42);

        Assert.Equal(42, stack.Top());
        Assert.Equal(42, stack.GetMin());

        stack.Pop();

        Assert.Throws<InvalidOperationException>(() => stack.Top());
        Assert.Throws<InvalidOperationException>(() => stack.GetMin());
    }

    [Fact]
    public void PushMultipleElements_GetMinTracksMinimum()
    {
        var stack = new MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);

        Assert.Equal(7, stack.Top());
        Assert.Equal(3, stack.GetMin());

        stack.Pop(); // Remove 7
        Assert.Equal(3, stack.GetMin());

        stack.Pop(); // Remove 3
        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void GetMin_WithDuplicateMinimums()
    {
        var stack = new MinStack();
        stack.Push(4);
        stack.Push(2);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Top());
        Assert.Equal(2, stack.GetMin());

        stack.Pop(); // Remove 3
        stack.Pop(); // Remove 2
        Assert.Equal(2, stack.GetMin());

        stack.Pop(); // Remove 2
        Assert.Equal(4, stack.GetMin());
    }

    [Fact]
    public void PushPopPush_GetMinUpdatesCorrectly()
    {
        var stack = new MinStack();
        stack.Push(10);
        stack.Push(5);
        stack.Pop();
        stack.Push(7);

        Assert.Equal(7, stack.Top());
        Assert.Equal(7, stack.GetMin());
    }
}
