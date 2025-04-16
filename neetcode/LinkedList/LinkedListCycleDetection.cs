using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.LinkedList;
public static class LinkedListCycleDetection
{
    public static bool HasCycle(ListNode head)
    {
        var p1 = head;
        var p2 = head.next;

        while (p1 != null && p2 != null)
        {
            if (p1 == p2)
                return true;

            p1 = p1.next;
            p2 = p2?.next?.next;
        }

        return false;
    }
}
