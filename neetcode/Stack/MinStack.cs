namespace neetcode.Stack;
public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _minStack = new();

    public void Push(int val)
    {
        _stack.Push(val);

        if (_minStack.Count == 0) _minStack.Push(val);
        else if (val < _minStack.Peek()) _minStack.Push(val);
        else _minStack.Push(_minStack.Peek());
    }

    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _minStack.Peek();
    }
}
