namespace neetcode.ArraysAndHashing;
public static class TopKFrequentElements
{ 
    // f(t) : O(n*log(n) + log(k)) 
    // f(s) : O(k)
    public static int[] TopKFrequentMaxHeap(int[] nums, int k)
    {
        Dictionary<int, int> elementCount = new();
        foreach (int num in nums)
            elementCount[num] = elementCount.GetValueOrDefault(num) + 1;

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach(var key in elementCount.Keys)
                maxHeap.Enqueue(key, elementCount[key]);

        int[] result = new int[k];
        for (int i = 0; i < k; i++)
            result[i] = maxHeap.Dequeue();

        return result;
    }



    // f(t) : O(n + n*log(k) ) 
    // f(s) : O(n + k)
    public static int[] TopKFrequentMinHeap(int[] nums, int k)
    {
        Dictionary<int, int> elementCount = new();
        foreach (int num in nums)
            elementCount[num] = elementCount.GetValueOrDefault(num) + 1;

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        foreach (var key in elementCount.Keys)
        {
            minHeap.Enqueue(key, elementCount[key]);
            
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        var result = new int[k];
        for(int i = 0; i < k; i++)
            result[i] = minHeap.Dequeue();

        return result;
    }
}
