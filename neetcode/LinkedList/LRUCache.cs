using System.Xml.Linq;

namespace neetcode.LinkedList;


public class DoublyLinkedList
{
    public DoublyLinkedList() { }

    public int Key { get; set; }
    public int Val { get; set; }
    public DoublyLinkedList? Left { get; set; }
    public DoublyLinkedList? Right { get; set; }
}

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

            return node.Val;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        DoublyLinkedList node;
        if (_valueMap.TryGetValue(key, out node))
        {
            node.Val = value;
            PopNode(node);
            PushMru(node);

            return;
        }

        if (_capacity == _valueMap.Count)
        {
            PopNode(LRUSentintel.Right);
        }

        node = new DoublyLinkedList() { Key = key, Val = value };
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
}
