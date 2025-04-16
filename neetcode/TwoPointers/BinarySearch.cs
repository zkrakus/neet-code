using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.TwoPointers;
public static class BinarySearch
{
    /// <summary>
    /// s: O(1)
    /// t: O(log(n))
    /// </summary>
    public static int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;

        var i = 0;
        var j = nums.Length - 1;
        while (j >= i)
        {
            var mid = i + (j - i) / 2;

            if (target == nums[mid])
                return mid;

            if (target < nums[mid])
                j = mid - 1;
            else
                i = mid + 1;
        }

        return -1;
    }
}







