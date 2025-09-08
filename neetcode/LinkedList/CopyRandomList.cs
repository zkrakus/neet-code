using System;
using System.Xml.Linq;

namespace neetcode.LinkedList;
public static class CopyRandomList
{
    public static ListNode? CopyRandomListTwoPass(ListNode head)
    {
        if (head is null)
            return null;
        
        Dictionary<ListNode, ListNode> oldToNew =  new();

        ListNode cur = head;
        while (cur != null)
        {
            ListNode copy = new ListNode(cur.val);
            oldToNew[cur] = copy;
            cur = cur.next;
        }

        cur = head;
        while (cur != null)
        {
            ListNode copy = oldToNew[cur];
            copy.next = cur.next != null ? oldToNew[cur.next] : null;
            copy.other = cur.other != null ? oldToNew[cur.other] : null;
            cur = cur.next!;
        }

        return head != null ? oldToNew[head] : null;
    }
}
