namespace neetcode.Stack;

public static class ValidParentheses
{
    public static bool IsValid0(string s)
    {
        if (s.Length == 0)
            return true;

        var parenthesesStack = new Stack<char>();
        var bracketsStack = new Stack<char>();
        var bracesStack = new Stack<char>();
        char lastOpeningDelimiter = 'd'; // Just a non-null placeholder.

        foreach (char c in s)
        {
            if (c is '(')
                parenthesesStack.Push(c);
            else if (c is ')' && lastOpeningDelimiter == '(')
            {
                if (!parenthesesStack.TryPop(out var p))
                    return false;

            }

            if (c is '[')
                bracketsStack.Push(c);
            else if (c is ']' && lastOpeningDelimiter == '[')
            {
                if (!bracketsStack.TryPop(out var p))
                    return false;

            }

            if (c is '{')
                bracesStack.Push(c);
            else if (c is '}' && lastOpeningDelimiter == '{')
            {
                if (!bracesStack.TryPop(out var p))
                    return false;

            }
        }

        if (parenthesesStack.Count != 0)
            return false;

        if (bracketsStack.Count != 0)
            return false;

        if (bracesStack.Count != 0)
            return false;

        return true;
    }

    public static bool IsValid(string s)
    {
        if (s.Length == 0)
            return true;

        var delimeterStack = new Stack<char>();
        var closeDelimeterPair = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        var openDelimeter = new HashSet<char>() { '(', '[', '{' };

        foreach (char c in s)
        {
            if (closeDelimeterPair.ContainsKey(c) || openDelimeter.Contains(c))
            {
                if (openDelimeter.Contains(c))
                    delimeterStack.Push(c);
                else if (closeDelimeterPair.ContainsKey(c))
                {
                    if (delimeterStack.Count == 0 || (closeDelimeterPair[c] != delimeterStack.Peek()))
                        return false;

                    delimeterStack.Pop();
                }
            }
        }

        return delimeterStack.Count == 0;
    }
}
