using System.Globalization;

namespace neetcode.LinkedList;
public static class AddTwoNumbers
{
    public static ListNode? AddTwoNumbersSentinel(ListNode l1, ListNode l2)
    {
        if (l1 is null || l2 is null)
            return null!;

        ListNode sentinel = new(0), tail = sentinel;
        ListNode cur1 = l1, cur2 = l2;
        bool carry = false;
        while (cur1 is not null && cur2 is not null)
        {
            var newVal = cur1.val + cur2.val;
            if (carry) 
                newVal++;

            carry = newVal > 9;
            newVal %= 10;

            tail.next = new(newVal);
            tail = tail.next;

            cur1 = cur1.next!;
            cur2 = cur2.next!;
        }

        // swap back to cur 1 so we only need to write logic for one of the possibly unfinished lists..
        if (cur2 is not null)
            cur1 = cur2;

        while (cur1 != null)
        {
            var newVal = cur1.val;
            if (carry)
            {
                newVal++;
                if(newVal > 9)
                {
                    carry = true;
                    newVal %= 10;
                }
            }

            tail.next = new(newVal);
            tail = tail.next;
            cur1 = cur1.next!;
        }

        if (carry)
            tail.next = new ListNode(1);

        return sentinel.next;
    }
}
