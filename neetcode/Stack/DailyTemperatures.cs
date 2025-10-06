namespace neetcode.Stack;
public static class DailyTemperatures
{
    public static int[] SolveStack(int[] temperatures)
    {
        Stack<(int value, int index)> tempStack = new();
        var result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            var curTemp = temperatures[i];
            while (tempStack.Count != 0 && tempStack.Peek().value < curTemp)
            {
                ( _ , int prevIndex) = tempStack.Pop();
                result[prevIndex] = i - prevIndex;
            }
            
            tempStack.Push((curTemp, i));
        }

        return result;
    }

    // I don't like this solution. Not mine.
    public static int[] SolveReverse(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] res = new int[n];

        for (int i = n - 2; i >= 0; i--)
        {
            int j = i + 1;
            while (j < n && temperatures[j] <= temperatures[i])
            {
                if (res[j] == 0)
                {
                    j = n;
                    break;
                }
                j += res[j];
            }

            if (j < n)
            {
                res[i] = j - i;
            }
        }
        return res;
    }
}
