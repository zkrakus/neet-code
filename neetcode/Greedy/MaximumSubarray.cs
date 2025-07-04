using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Greedy;
public static class MaximumSubarray
{
    public static int MaxSubArray(int[] nums)
    {
        int maxSub = nums[0], curSum = 0;
        foreach (int num in nums)
        {
            if(curSum < 0) {
                curSum = 0;
            }

            curSum += num;
            maxSub = Math.Max(maxSub, curSum);
        }

        return maxSub;
    }
}
