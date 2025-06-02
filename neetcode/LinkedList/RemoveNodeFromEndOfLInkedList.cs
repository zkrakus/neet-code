using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.LinkedList;
public static class RemoveNodeFromEndOfLInkedList
{
    public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
    {
        if (head is null || head?.next is null)
            return head;

        ListNode? g = head;
        ListNode? prevNthNode = null;
        for (int i = 0; i < n; i++)
        {
            prevNthNode = g;
            g = g.next;

        }

        ListNode l = head;
        while (g.next != null)
        {
            g = g.next;
            l = l.next;
        }

        return head;
    }
}
