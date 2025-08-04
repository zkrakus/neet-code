using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Greedy;
public static class MaximumSubarray
{

    public static int MaxSubArrayBrute(int[] nums)
    {
        if (nums is null || nums.Length == 0) return 0;

        int max = int.MinValue;
        for(int i = 0; i < nums.Length; i++)
        {
            int curMax = 0;
            for(int j = 0; j < nums.Length; j++)
            {
                curMax += nums[j];
                max = Math.Max(max, curMax);
            }
        }

        return max;
    }

    // Kadane's
    // https://neetcode.io/courses/advanced-algorithms/0
    public static int MaxSubArray(int[] nums)
    {
        // Initialize both current sum and max sum with the first element.
        // This handles cases where all numbers are negative, because the max subarray
        // must be at least one element and we start by assuming the first is the best.
        int curSum = nums[0];
        int maxSub = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            // Decision point:
            // - Either start a new subarray (sliding window) at the current number nums[i],
            // - Or extend the existing subarray (sliding window) by adding nums[i] to curSum.
            // This comparison works correctly for all negatives or any mix of values.
            curSum = Math.Max(nums[i], curSum + nums[i]);

            // Update the global maximum with the best sum found so far.
            maxSub = Math.Max(maxSub, curSum);
        }

        return maxSub;
    }

    // Kadane's sliding window
    public static (int, int) MaxSubArray(int[] nums)
    {
        int curSum = nums[0];
        int maxSum = nums[0];

        // Track window boundaries
        int curL = 0;     // current subarray start
        int maxL = 0;     // best subarray start
        int maxR = 0;     // best subarray end

        for (int i = 1; i < nums.Length; i++)
        {
            // Decision: start new subarray at i or extend existing
            if (nums[i] > curSum + nums[i])
            {
                curSum = nums[i];
                curL = i;             // reset current window start
            }
            else
            {
                curSum += nums[i];    // extend current window
            }

            // Update best window if new sum is larger
            if (curSum > maxSum)
            {
                maxSum = curSum;
                maxL = curL;
                maxR = i;
            }
        }

        return (maxL, maxR);
    }


    // Do dynamic programming solution as well.
}
