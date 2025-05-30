namespace neetcode.LinkedList;

public static class ReverseLinkedList
{

    public static ListNode? ReverseList(ListNode? head)
    {
        if (head is null || head.next is null)
            return head;

        ListNode cur = head;
        ListNode prev = null!;
        while (cur != null)
        {
            ListNode tmp = cur.next!;
            cur.next = prev;
            prev = cur;
            cur = tmp;
        }

        return prev;
    }

    public static ListNode? ReverseListRecursive(ListNode? head)
    {
        if (head is null || head.next is null)
            return head;


        static ListNode? ReverseListRec(ListNode? cur, ListNode? prev)
        {
            if (cur is null)
                return prev;

            var tmp = cur.next;
            cur.next = prev!;
            prev = cur;
            cur = tmp;

            return ReverseListRec(cur, prev);
        }

        return ReverseListRec(head, null);
    }
}
