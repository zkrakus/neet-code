namespace neetcode.Stack;
internal class DailyTemperatures
{
    public static string Solve(int[] temperatures)
    {
        Stack<(int, int)> tempStack = new();
        var result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            if (i == temperatures.Length - 1)
                result[i] = 0;

            var curTemp = temperatures[i];
            if (tempStack.Count != 0 && tempStack.Peek().Item1 < curTemp)
            {
                (int value, int index) = tempStack.Pop();
                result[index] = index - i;
            }
            
            tempStack.Push((curTemp, i));
            if (curTemp  )
            {

            }
        }

        return result;
    }
}
