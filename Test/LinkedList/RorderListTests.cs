using neetcode.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.LinkedList;
public class RorderListTests
{
    private ListNode CreateList(params int[] values)
    {
        if (values.Length == 0) return null!;
        var head = new ListNode(values[0]);
        var current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
        return head;
    }

    private List<int> ToList(ListNode? head)
    {
        var result = new List<int>();
        while (head != null)
        {
            result.Add(head.val);
            head = head.next;
        }
        return result;
    }

    [Theory]
    [InlineData(new int[] { }, new int[] { })]
    [InlineData(new int[] { 1 }, new int[] { 1 })]
    [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4, 2, 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 5, 2, 4, 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 6, 2, 5, 3, 4 })]
    public void Reorder_ReordersListCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var head = CreateList(input);

        // Act
        var reordered = ReorderList.Reorder(head);

        // Assert
        Assert.Equal(expected, ToList(reordered));
    }
}