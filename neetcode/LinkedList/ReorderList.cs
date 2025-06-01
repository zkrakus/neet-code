namespace neetcode.LinkedList;
public static class ReorderList
{
    public static ListNode? Reorder(ListNode? head)
    {
        if (head is null || head.next is null)
            return head;

        ListNode? t = head;
        ListNode? h = head?.next;
        while (h?.next != null)
        {
            t = t?.next;
            h = h?.next?.next;
        }

        h = t!.next; // The new right pointer is now the beginning of the secondary linked list.
        t.next = null; // Sever the pointer from the first linked list from the second.
        static ListNode? ReverseLinkedListRec(ListNode? prev, ListNode? cur)
        {
            if (cur is null)
                return prev!;

            var tmp = cur.next;
            cur.next = prev;

            return ReverseLinkedListRec(cur, tmp); // prev = cur, cur = tmp;
        }

        h = ReverseLinkedListRec(null, h);

        // Merge the two halves: first half (starting at 'head') and reversed second half (starting at 'h')
        t = head;
        while (t is not null && h is not null)
        {
            var tmp = t.next;
            t.next = h;
            t = h;
            h = tmp;
        }

        return head!;
    }
}
