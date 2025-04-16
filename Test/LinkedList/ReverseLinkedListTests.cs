using neetcode.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.LinkedList;

public class ReverseLinkedListTests
{
    private ListNode BuildList(int[] values)
    {
        if (values == null || values.Length == 0) return null!;
        var head = new ListNode(values[0]);
        var current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
        return head;
    }

    private int[] ToArray(ListNode head)
    {
        var result = new List<int>();
        var current = head;
        while (current != null)
        {
            result.Add(current.val);
            current = current.next;
        }
        return result.ToArray();
    }

    [Fact]
    public void SingleNodeList_ReturnsSameNode()
    {
        var head = BuildList(new[] { 1 });
        var result = ReverseLinkedList.ReverseList(head);
        Assert.Equal(new[] { 1 }, ToArray(result));
    }

    [Fact]
    public void TwoNodeList_IsReversed()
    {
        var head = BuildList(new[] { 1, 2 });
        var result = ReverseLinkedList.ReverseList(head);
        Assert.Equal(new[] { 2, 1 }, ToArray(result));
    }

    [Fact]
    public void MultiNodeList_IsReversed()
    {
        var head = BuildList(new[] { 1, 2, 3, 4, 5 });
        var result = ReverseLinkedList.ReverseList(head);
        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, ToArray(result));
    }

    [Fact]
    public void NullHead_ReturnsNull()
    {
        var result = ReverseLinkedList.ReverseList(null!);
        Assert.Null(result);
    }

    [Fact]
    public void ListWithDuplicateValues_IsReversed()
    {
        var head = BuildList(new[] { 1, 2, 3, 2, 1 });
        var result = ReverseLinkedList.ReverseList(head);
        Assert.Equal(new[] { 1, 2, 3, 2, 1 }, ToArray(result));
    }
}
