using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.HeapAndPriorityQueue;
public class KthLargestElementInAStream
{
    private PriorityQueue<int, int> _minHeap = new();
    private int? k = null;

    public KthLargestElementInAStream(int k, int[] nums)
    {
        this.k = k;

        foreach(int item in nums)
            _minHeap.Enqueue(item, item);

        while(_minHeap.Count > k)
            _minHeap.Dequeue();
    }

    public int Add(int val)
    {
        _minHeap.Enqueue(val, val);

        if (_minHeap.Count > k)
            _minHeap.Dequeue();

        return _minHeap.Peek();
    }
}
