namespace neetcode.TwoPointers;
public static class ContainerWithMostWater
{
    public static int MaxArea(int[] heights)
    {
        if (heights is null || heights.Length == 0) return 0;

        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
            for (int j = i + 1; j < heights.Length; j++)
                maxArea = Math.Max(maxArea, Math.Min(heights[i], heights[j]) * j - i);

        return maxArea;
    }
}
