namespace neetcode.Stack;
public static class DailyTemperatures
{
    public static int[] Solve(int[] temperatures)
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
}
