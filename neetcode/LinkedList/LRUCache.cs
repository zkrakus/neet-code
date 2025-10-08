namespace neetcode.LinkedList;

public class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, DoublyLinkedList> _valueMap = new();
    private DoublyLinkedList LRUSentintel { get; set; } = new();
    private DoublyLinkedList MRUSentintel { get; set; } = new();

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        LRUSentintel.Right = MRUSentintel;
        MRUSentintel.Left = LRUSentintel;
    }

    public int Get(int key)
    {
        if (_valueMap.TryGetValue(key, out var node))
        {
            PopNode(node);
            PushMru(node);

            return node.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        DoublyLinkedList node;
        if (_valueMap.TryGetValue(key, out node))
        {
            node.Value = value;
            PopNode(node);
            PushMru(node);

            return;
        }

        if (_capacity == _valueMap.Count)
        {
            PopNode(LRUSentintel.Right);
        }

        node = new DoublyLinkedList() { Key = key, Value = value };
        _valueMap[key] = node;

        PushMru(node);
    }

    private void PopNode(DoublyLinkedList node)
    {
        node.Right.Left = node.Left;
        node.Left.Right = node.Right;
        _valueMap.Remove(node.Key);
    }

    private void PushMru(DoublyLinkedList node)
    {
        var temp = MRUSentintel.Left;
        MRUSentintel.Left = node;
        temp.Right = node;

        node.Right = MRUSentintel;
        node.Left = temp;
        _valueMap[node.Key] = node;
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedList(int key = 0, int value = 0)
        {
            Key = key;
            Value = value;
        }

        public int Key { get; set; }
        public int Value { get; set; }
        public DoublyLinkedList? Left { get; set; }
        public DoublyLinkedList? Right { get; set; }
    }
}