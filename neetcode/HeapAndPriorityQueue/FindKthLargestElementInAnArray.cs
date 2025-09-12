namespace neetcode.HeapAndPriorityQueue;

public class FindKthLargestElementInAnArray
{
    // t(n): O(n log(k))
    // s(n): O(k);
    public int FindKthLargest(int[] nums, int k)
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
}
