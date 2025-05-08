using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.HeapAndPriorityQueue;
public static class LastStoneWeight
{
    public static int FindLastStoneWeight(int[] stones)
    {
        if (stones is null || stones.Length == 0)
            return 0;

        if (stones.Length == 1)
            return stones[0];

        PriorityQueue<int, int> minHeap = new();
        foreach (int stone in stones)
            minHeap.Enqueue(stone, stone * -1);

        var stone1 = minHeap.Dequeue();
        while (minHeap.Count > 0)
        {
            var stone2 = minHeap.Dequeue();

            if (stone1 > stone2)
                stone1 -= stone2;
            else if (stone2 > stone1)
                stone1 = stone2 - stone1;
            else
            {
                if (minHeap.Count > 0)
                    stone1 = minHeap.Dequeue();
                else
                    stone1 = 0;
            }
        }

        return stone1;
    }

    public static int FindLastStoneWeight2(int[] stones)
    {
        if (stones is null || stones.Length == 0)
            return 0;

        PriorityQueue<int, int> minHeap = new();
        foreach (int stone in stones)
            minHeap.Enqueue(stone, stone * -1);

        while (minHeap.Count > 1)
        {
            var stone1 = minHeap.Dequeue();
            var stone2 = minHeap.Dequeue();

            if (stone1 != stone2)
                minHeap.Enqueue(stone2 - stone1, -(stone2 - stone1));
        }

        return minHeap.Count == 1 ? minHeap.Dequeue() : 0;
    }
}
