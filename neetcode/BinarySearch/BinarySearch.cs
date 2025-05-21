namespace neetcode.BinarySearch;
public static class BinarySearch
{
    /// <summary>
    /// s: O(log(n)) Log of n space because uses the call stack for left and right.
    /// t: O(log(n))
    /// </summary>
    public static int BinarySearchRec(int[] nums, int target)
    {
        if (nums is null || nums.Length == 0)
            return -1;

        int BinarySearchRecursive(int left, int right)
        {
            if (left > right) return -1;

            int mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;

            if (nums[mid] > target)
                return BinarySearchRecursive(left, mid - 1);
            else
                return BinarySearchRecursive(mid + 1, right);
        }

        return BinarySearchRecursive(0, nums.Length - 1);
    }

    /// <summary>
    /// s: O(1)
    /// t: O(log(n))
    /// </summary>
    public static int BinarySearchIt(int[] nums, int target)
    {
        if (nums is null || nums.Length == 0)
            return -1;

        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int cur = nums[mid];

            if (cur == target) return mid;
            else if (target < cur) right = mid - 1;
            else left = mid + 1;
        }

        return -1;
    }
}
