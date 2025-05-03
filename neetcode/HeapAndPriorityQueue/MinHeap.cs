namespace neetcode.HeapAndPriorityQueue;
public class MinHeap
{
    private readonly List<int> _elements = new();

    public int Count => _elements.Count;

    public int Peak() => _elements[0];

    private void Swap(int i, int j)
    {
        (_elements[i], _elements[j]) = (_elements[j], _elements[i]);
    }

    private void HeapifyUp(int index)
    {
        // Keep bubbling the node up until it reaches the root or no swap is needed.
        while (index > 0)
        {
            // Memorize and understand this operation.
            int parent = (index - 1) / 2;
            if (_elements[index] >= _elements[parent])
                break;

            Swap(index, parent);
            index = parent;
        }
    }

    private void HeapifyDown(int parentIndex)
    {
        // We continue while parentIndex < Count to ensure we're within bounds of the heap.
        // Each iteration compares the current node with its children to determine if a swap is needed.
        // The loop stops when the current node has no children (i.e., leftChildIndex child parentIndex ≥ Count),
        // or when the heap property is satisfied (handled inside the loop).
        // Using parentIndex < Count prevents out-of-range access when calculating child indices (2i + 1, 2i + 2).
        while (parentIndex < Count)
        {
            // Memorize and understand this operation in terms of how to construct array based trees.
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = 2 * parentIndex + 2;
            
            // This is an assumption and default value.
            int smallestIndex = parentIndex;

            // Check if leftChildIndex is within bounds (i.e., a valid node in the heap)
            // and if the value at that index is smaller than the current smallest.
            if (leftChildIndex < Count && _elements[leftChildIndex] < _elements[smallestIndex])
                smallestIndex = leftChildIndex;

            // Repeat for the right child.
            if (rightChildIndex < Count && _elements[rightChildIndex] < _elements[smallestIndex])
                smallestIndex = rightChildIndex;

            // If the parent is still the smallest, the heap property is satisfied.
            if (smallestIndex == parentIndex)
                break;

            // Otherwise, swap the parent with the smaller child and continue downward.
            Swap(parentIndex, smallestIndex);
            parentIndex = smallestIndex;
        }
    }

    public void Add(int item)
    {
        _elements.Add(item);
        HeapifyUp(_elements.Count - 1);
    }

    public int Pop()
    {
        int result = _elements[0];
        // Take last element and move to front.
        _elements[0] = _elements[^1];

        // Remove last element.
        _elements.RemoveAt(_elements.Count - 1);
        
        // Then reheapify the element from the end. 
        // This is a impelementation detail of array based trees.
        // We don't want to rebuild the heap again and we can't have gaps in the tree based array (like we would we we try to reposition the pop elements children)
        // So instead of rebuilding the heap we just reheapify the last element to maintain O(log n) time complexity.
        HeapifyDown(0);
        return result;
    }
}
