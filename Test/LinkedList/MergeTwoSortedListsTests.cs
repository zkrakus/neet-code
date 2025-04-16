using neetcode.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.LinkedList;
public class MergeTwoSortedListsTests
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
        while (head != null)
        {
            result.Add(head.val);
            head = head.next;
        }
        return result.ToArray();
    }

    [Fact]
    public void BothListsNull_ReturnsNull()
    {
        var result = MergeTwoSortedLists.MergeTwoLists(null!, null!);
        Assert.Null(result);
    }

    [Fact]
    public void OneListNull_ReturnsOtherList()
    {
        var list1 = BuildList(new[] { 1, 3, 5 });
        var result = MergeTwoSortedLists.MergeTwoLists(list1, null!);
        Assert.Equal(new[] { 1, 3, 5 }, ToArray(result));
    }

    [Fact]
    public void MergesTwoSortedLists()
    {
        var list1 = BuildList(new[] { 1, 2, 4 });
        var list2 = BuildList(new[] { 1, 3, 5 });
        var result = MergeTwoSortedLists.MergeTwoLists(list1, list2);
        Assert.Equal(new[] { 1, 1, 2, 3, 4, 5 }, ToArray(result));
    }

    [Fact]
    public void MergesWithDuplicates()
    {
        var list1 = BuildList(new[] { 2, 2, 4 });
        var list2 = BuildList(new[] { 2, 2, 5 });
        var result = MergeTwoSortedLists.MergeTwoLists(list1, list2);
        Assert.Equal(new[] { 2, 2, 2, 2, 4, 5 }, ToArray(result));
    }

    [Fact]
    public void MergesWithNegativeValues()
    {
        var list1 = BuildList(new[] { -10, -3, 0 });
        var list2 = BuildList(new[] { -5, 1, 2 });
        var result = MergeTwoSortedLists.MergeTwoLists(list1, list2);
        Assert.Equal(new[] { -10, -5, -3, 0, 1, 2 }, ToArray(result));
    }

    [Fact]
    public void InterleavedMerge()
    {
        var list1 = BuildList(new[] { 1, 4, 6 });
        var list2 = BuildList(new[] { 2, 3, 5 });
        var result = MergeTwoSortedLists.MergeTwoLists(list1, list2);
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, ToArray(result));
    }
}
