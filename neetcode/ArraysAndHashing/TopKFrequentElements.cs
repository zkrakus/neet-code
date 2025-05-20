namespace neetcode.ArraysAndHashing;
public static class TopKFrequentElements
{
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> elementCount = new();
        foreach (int i in nums)
            elementCount[i] = elementCount.GetValueOrDefault(i) + 1;

        PriorityQueue<int, int> minHeap = new(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        foreach (var element in elementCount.Keys)
            minHeap.Enqueue(element, elementCount[element]);

        var result = new int[k];
        for (int i = 0; i < k; i++)
            result[i] = minHeap.Dequeue();

        return result;
    }
}
