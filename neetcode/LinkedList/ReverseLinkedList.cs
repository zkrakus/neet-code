namespace neetcode.LinkedList;

public static class ReverseLinkedList
{

    public static ListNode? ReverseList(ListNode head)
    {
        if (head is null || head.next is null)
            return head;

        ListNode prev = null!;
        var cur = head;
        while (cur != null)
        {
            var temp = cur.next; // keep track of next
            cur.next = prev; // set the next to prevoius ... starts as null. First iteration this will set next to null which will be our ending delimeter.
            prev = cur; // set the new previous to current
            cur = temp; // set the new current to the next value
        }

        return prev;
    }
}
