using System.Security.AccessControl;

namespace neetcode.BinarySearch;
public static class FindMinimumInSortedArray
{
    public static int FindMin(int[] nums)
    {
        if(nums is null || nums.Length == 0)
            return int.MinValue;

        int l = 0, r = nums.Length - 1;
        int res = int.MinValue;
        while (l <= r)
        {
            if (nums[l] < nums[r]) // unsure about why this has to be handled seperately.
            {
                res = Math.Min(res, nums[l]);
                break;
            }

            int m = l + (r - l) / 2;
            if (nums[m] >= nums[l])
            {
                l = m + 1;
                res = Math.Min(nums[r], nums[l]);
            }
            else
            {
                r = m - 1; // Unsure about this minus 1?
                res = Math.Min(nums[r], nums[l]);
            }
        }

        return res;
    }
}
