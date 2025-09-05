namespace neetcode.TwoPointers;
internal static class TrappingRainWater
{
    // t = O(n)
    // s = O(n)
    //public static int Trap(int[] heights)
    //{
    //    if (heights is null || heights.Length < 3)
    //        return 0;

    //    int[] leftMaxHeights = new int[heights.Length];
    //    leftMaxHeights[0] = 0;
    //    for (int i = 1; i < heights.Length; i++)
    //        leftMaxHeights[i] = Math.Max(leftMaxHeights[i - 1], heights[i]);

    //    int[] rightMaxHeights = new int[heights.Length];
    //    rightMaxHeights[heights.Length - 1] = 0;
    //    for (int i = heights.Length - 2; i > 0; i--)
    //        rightMaxHeights[i] = Math.Max(rightMaxHeights[i + 1], heights[i]);

    //    var totalRainwater = 0;
    //    for(int i = 0; i < heights.Length; i++)
    //    {
    //        var rainTrapped = Math.Min(leftMaxHeights[i], rightMaxHeights[i]) - heights[i];
    //        if(rainTrapped > 0)
    //            totalRainwater += rainTrapped;
    //    }

    //    return totalRainwater;
    //}

    // t: O(n)
    // s: O(1)
    public static int TrapTwoPoitners(int[] heights)
    {
        if (heights is null || heights.Length < 3)
            return 0;

        int l = 0, r = heights.Length - 1;
        int maxLeft = heights[0], maxRight = heights[^1];
        int totalTrappedRainWater = 0;
        while (l < r)
        {
            if (maxLeft < maxRight)
            {
                maxLeft = Math.Max(maxLeft, heights[l]);
                totalTrappedRainWater += maxLeft - heights[l];
                l++;
            }
            else
            {
                r--;
                maxRight = Math.Max(maxRight, heights[r]);
                totalTrappedRainWater += maxRight - heights[r];
            }
        }

        return totalTrappedRainWater;
    }
}
