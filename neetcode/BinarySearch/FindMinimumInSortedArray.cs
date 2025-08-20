namespace neetcode.BinarySearch;
public static class FindMinimumInSortedArray
{

    public static int FindMin2(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return int.MinValue;

        int l = 0, r = nums.Length - 1; // Initialize binary search
        while (l < r) // Can we binary search?
        {
            if (nums[l] <= nums[r]) // Is our subarray sorted?
                break;

            int m = l + (r - l) / 2; // Find mid
            if (nums[l] < nums[m]) // Is our left sub array sorted?
                l = m + 1; // Is so check right unsorted subarray?
            else // Otherwise check left unsorted subarray
                r = m;
        }

        return nums[l]; // returned min of sorted subarray
    }
}