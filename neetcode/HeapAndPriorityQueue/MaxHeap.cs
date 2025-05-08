using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.HeapAndPriorityQueue;
public class MaxHeap
{
    private readonly List<int> _elements = new();

    public int Count => _elements.Count;

    public int Peak() => _elements.Count == 0 ? throw new InvalidOperationException("Heap is empty") : _elements[0];

    private void Swap(int i, int j)
    {
        (_elements[i], _elements[j]) = (_elements[j], _elements[i]);
    }

    public int Pop()
    {
        var result = _elements[0];
        _elements[0] = _elements[^1];
        _elements.RemoveAt(Count - 1);
        HeapifyDown(0);
        return result;
    }

    public void Push(int item)
    {
        _elements.Add(item);
        HeapifyUp(Count - 1);
    }

    private void HeapifyDown(int parentIndex)
    {
        while (parentIndex < Count)
        {
            var leftChildIndex = 2 * parentIndex + 1;
            var rightChildIndex = 2 * parentIndex + 2;
            var largest = parentIndex;

            if (leftChildIndex < Count && _elements[leftChildIndex] >= _elements[largest])
                largest = leftChildIndex;

            if (rightChildIndex < Count && _elements[rightChildIndex] >= _elements[largest])
                largest = rightChildIndex;

            if (largest == parentIndex)
                break;

            Swap(largest, parentIndex);
            parentIndex = largest;
        }
    }

    private void HeapifyUp(int childIndex)
    {
        while (childIndex > 0)
        {
            var parentIndex = (childIndex - 1) / 2;
            if (_elements[childIndex] < _elements[parentIndex])
                break;

            Swap(childIndex, parentIndex);
            childIndex = parentIndex;
        }
    }
}
