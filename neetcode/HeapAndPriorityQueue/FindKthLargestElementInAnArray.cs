namespace neetcode.HeapAndPriorityQueue;

public static class FindKthLargestElementInAnArray
{
    // t(n): O(n log(k))
    // s(n): O(k);
    public static int FindKthLargestMinHeap(int[] nums, int k)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if(minHeap.Count > k)
                minHeap.Dequeue();
        }

        return minHeap.Peek();
    }

    // t(n): O(n) on average. O(n^2) worst case.
    // s(n): O(k);
    // Quick select algorithm: 
    public static int FindKthLargestQuickSelect(int[] nums, int k)
    {

        k = nums.Length - k;
        int QuickSelect(int left, int right)
        {
            int pivot = nums[right];
            int p = left;

            // Lomuto partition
            for (int i = left; i < right; i++)
            {
                if (nums[i] <= pivot)
                {
                    (nums[i], nums[p]) = (nums[p], nums[i]);
                    p++;
                }
            }

            (nums[p], nums[right]) = (nums[right], nums[p]);

            if (p > k)
                return QuickSelect(left, p - 1);
            else if (p < k)
                return QuickSelect(p + 1, right);
            else
                return nums[p];
        }

        return QuickSelect(0, nums.Length - 1);
    }
}
