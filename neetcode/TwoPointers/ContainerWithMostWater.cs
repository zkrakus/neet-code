namespace neetcode.TwoPointers;
public static class ContainerWithMostWater
{
    public static int MaxAreaBrute(int[] heights)
    {
        if (heights is null || heights.Length == 0) return 0;

        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
            for (int j = i + 1; j < heights.Length; j++)
                maxArea = Math.Max(maxArea, Math.Min(heights[i], heights[j]) * j - i);

        return maxArea;
    }

    public static int MaxAreaTwoPointers(int[] heights)
    {
        if (heights is null || heights.Length == 0) return 0;

        int left = 0, right = heights.Length - 1;
        int maxArea = 0;
        while (right > left)
        {
            maxArea = right - left * Math.Min(heights[left], heights[right]);
            if (heights[left] > heights[right]) right--;
            else left++;
        }

        return maxArea;
    }
}
