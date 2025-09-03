namespace neetcode.BinarySearch;
public static class SearchInRotatedSortedArray
{
    public static int Search(int[] nums, int target)
    {
        if (nums is null || nums.Length == 0)
            return -1;

        int BinarySearch(int l, int r)
        {
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target)
                    return mid;

                if (target > nums[mid])
                    l = mid + 1;
                else
                    r = mid - 1;
            }

            return -1;
        }

        int l = 0, r = nums.Length - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (nums[mid] == target)
                return mid;

            // left side is sorted
            if (nums[l] <= nums[mid])
            {
                // and target is in range
                if(target >= nums[l] && target < nums[mid])
                    return BinarySearch(l, mid);
                // and target is in unsorted side
                else 
                    l = mid + 1;
            }

            // Right side is sorted
            if (nums[mid + 1] < nums[r])
            {
                // and target is in range
                if (nums[mid + 1] < target && nums[r] >= target)
                    return BinarySearch(mid + 1, r);
                // and target is in unsorted side.
                else
                    r = mid - 1;
            }
        }

        return -1;
    }
}
