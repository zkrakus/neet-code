using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.TwoPointers;
public class ThreeSum
{
    public static List<List<int>> Sum(int[] nums)
    {
        if (nums is null || nums.Length < 3)
            return new List<List<int>>();

        List<List<int>> result = new();
        int[] numsCopy = nums.ToArray();
        Array.Sort(numsCopy);

        for(int i  = 0; i < numsCopy.Length; i++)
        {
            var val = numsCopy[i];

            if (i > 0 && val == numsCopy[i - 1])
                continue;

            int l = i + 1, r = numsCopy.Length - 1;
            while(l < r)
            {
                var threeSum = val + numsCopy[l] + numsCopy[r];
                if (threeSum > 0)
                    r--;
                else if (threeSum < 0)
                    l++;
                else
                {
                    result.Add(new List<int>() {val, numsCopy[l], numsCopy[r] });
                    l++;
                    while (numsCopy[l] == numsCopy[l-1] && l < r)
                    {
                        l++;
                    }
                }
               
            }
        }

        return result;
    }

    public static List<List<int>> Sum2(int[] nums)
    {
        if (nums is null || nums.Length < 3)
            return new List<List<int>> { };

        var targetTriplets = new List<List<int>>();
        var sortedNums = nums.ToArray();
        Array.Sort(sortedNums);
        var target = 0;

        int i = 0;
        while (i < sortedNums.Length - 2)
        {

            int left = i + 1, right = sortedNums.Length - 1;
            while (left < right)
            {
                var value = sortedNums[i] + sortedNums[left] + sortedNums[right];
                if (value == target)
                {
                    targetTriplets.Add(new List<int>(){ sortedNums[i], sortedNums[left], sortedNums[right] });
                    right = FindNextIndex(right, sortedNums, false);
                    left = FindNextIndex(left, sortedNums, true);
                }
                else if (value > target)
                {
                    right = FindNextIndex(right, sortedNums, false);
                }
                else if (value < target)
                {
                    left = FindNextIndex(left, sortedNums, true);
                }
            }

            i = FindNextIndex(i, sortedNums, true);
        }

        return targetTriplets;
    }

    /// direction: true = right, false = left.
    private static int FindNextIndex(int cur, int[] nums, bool direction = false)
    {
        if (direction)
        {
            int offset = 1;
            while (cur + offset < nums.Length - 1 && nums[cur + offset] == nums[cur])
            {
                offset++;
            }

            return cur + offset; ;
        }
        else
        {
            int offset = 1;
            while (cur - offset > 0 && nums[cur - offset] == nums[cur])
            {
                offset++;
            }

            return cur - offset;
        }
    }
}
