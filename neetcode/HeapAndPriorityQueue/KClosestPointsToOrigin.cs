namespace neetcode.HeapAndPriorityQueue;
public class KClosestPointsToOrigin
{
    public static int[][] KClosest(int[][] points, int k)
    {
        if (k <= 0) return Array.Empty<int[]>();

        //PriorityQueue<(int[] point, int priority), int> minHeap = new(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        PriorityQueue<(int[] point, int priority), int> maxHeap = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (var point in points)
        {
            // We technically can just use a**2 = b**2 because we care about relative distance by priority not the distance itself.
            // Using the distance itself will fuck shit up because of the sqrt operation ... we would have to use decimals or doubles.
            var distanceSquared = (point[0] * point[0]) + (point[1] * point[1]);

            // insert anything that's smaller than the smallest number. Will need to dequeue k, but minHeap will likely be larger than k up to a max of n.
            //if (minHeap.Count < k || distanceFromOrigin <= minHeap.Peek().priority)
            //    minHeap.Enqueue((point, distanceFromOrigin), distanceFromOrigin);

            // use max heap instead. Now we know the largest element k elements that we iterated over, so we will pop that largest element if we find a closer point, but keep size k.
            if (maxHeap.Count < k)
            {
                maxHeap.Enqueue((point, distanceSquared), distanceSquared);
            }
            else if (distanceSquared < maxHeap.Peek().priority)
            {
                maxHeap.Dequeue();
                maxHeap.Enqueue((point, distanceSquared), distanceSquared);
            }
        }

        return Enumerable.Range(0, k).Select(_ => maxHeap.Dequeue().point).ToArray();
    }
}
