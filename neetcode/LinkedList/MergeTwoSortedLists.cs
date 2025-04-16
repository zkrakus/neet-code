using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.LinkedList;

public static class MergeTwoSortedLists
{
    /// <summary>
    /// s(n): O(1)
    /// t(n): O(m + n)
    /// </summary>
    public static ListNode? MergeTwoLists(ListNode list1, ListNode list2)
    {
        var newHead = new ListNode();
        var previous = newHead;
        while (list1 is not null && list2 is not null)
        {
            if (list1.val < list2.val)
            {
                previous.next = list1;
                list1 = list1.next;
            }
            else
            {
                previous.next = list2;
                list2 = list2.next;
            }
            previous = previous.next;
        }

        if (list1 is not null)
            previous.next = list1;
        else if (list2 is not null)
            previous.next = list2;

        return newHead.next;
    }
}
