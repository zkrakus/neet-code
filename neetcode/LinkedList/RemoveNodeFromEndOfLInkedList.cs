namespace neetcode.LinkedList;
public static class RemoveNodeFromEndOfLInkedList
{
    public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
    {
        if (head is null || n <= 0) return head;

        ListNode? fast = head;
        for (int i = 0; i < n; i++)
        {
            if (fast is null) return head; // n > length
            fast = fast.next;
        }

        // If head has to be removed.
        if (fast is null) 
            return head.next;

        ListNode? prev = head; // We start at head and work with fast.next != null so we don't have to maintain a pointer behind cur so it's of no interest.
        while (fast.next != null)
        {
            prev = prev.next;
            fast = fast.next;
        }

        prev!.next = prev.next?.next;

        return head;
    }
}
