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
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (_elements[index] >= _elements[parent])
                break;

            Swap(index, parent);
            index = parent;
        }
    }

    private void HeapifyDown(int index)
    {
        while (index < Count)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int smallest = index;

            if (left < Count && _elements[left] < _elements[smallest])
                smallest = left;

            if (right < Count && _elements[right] < _elements[smallest])
                smallest = right;

            if (smallest == index)
                break;

            Swap(index, smallest);
            index = smallest;
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
        _elements[0] = _elements[^1];
        _elements.RemoveAt(_elements.Count - 1);
        HeapifyDown(0);
        return result;
    }
}
