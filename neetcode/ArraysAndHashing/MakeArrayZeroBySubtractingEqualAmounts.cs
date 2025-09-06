using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.ArraysAndHashing;

// https://leetcode.com/problems/make-array-zero-by-subtracting-equal-amounts/description/?envType=problem-list-v2&envId=7p5x763
public static class MakeArrayZeroBySubtractingEqualAmounts 
{
    // t: O(n)
    // s: t(n)
    public static int MinimumOperations(int[] nums)
    {
        if (nums is null)
            return 0;

        HashSet<int> numSet = new();
        for (int i = 0; i < nums.Length; i++)
        {
            var cur = nums[i];
            if (cur != 0)
                numSet.Add(cur);
        }

        return numSet.Count();
    }
}
