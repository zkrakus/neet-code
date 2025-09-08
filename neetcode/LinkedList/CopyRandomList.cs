using System;

namespace neetcode.LinkedList;
public static class CopyRandomList
{
    public static ListNode? CopyRandomListTwoPass(ListNode head)
    {
        if (head is null)
            return null;

        ListNode cur = head;
        var cur = root;
        ListNode? prev = null!;
        ListNode? newRoot = null!;
        Dictionary<ListNode, ListNode> originalToNewMap =  new();
        while (cur != null)
        {
            ListNode copy = new(cur.val);
            if (newRoot is null)
                newRoot = copy;
            else 
                prev.next = copy;

            originalToNewMap.Add(cur, copy);
            prev = copy;
            cur = cur.next;
        }
        
        cur = root;
        var newCur = newRoot;
        while (cur != null || newCur != null)
        {
            if (cur?.other != null)
                newCur!.other = originalToNewMap[cur.other];

            cur = cur?.next;
            newCur = newCur?.next;
        }

        return newRoot;
    }
}
