namespace neetcode.Stack;
public static class EvaluateReversePolishNotation
{

    public static int EvalRPN(string[] tokens)
    {
        Stack<int> _stack = new();
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var value))
            {
                _stack.Push(value);
            }
            else
            {
                switch (token)
                {
                    case "+":
                        _stack.Push(_stack.Pop() + _stack.Pop());
                        break;
                    case "-":
                        {
                            int x = _stack.Pop(), y = _stack.Pop();
                            _stack.Push(y - x);
                            break;
                        }
                    case "*":
                        _stack.Push(_stack.Pop() * _stack.Pop());
                        break;
                    case "/":
                        {
                            int x = _stack.Pop(), y = _stack.Pop();
                            _stack.Push(y / x);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        return _stack.Pop();
    }
}
