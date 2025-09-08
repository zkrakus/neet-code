using System.Net;
using System.Runtime.ConstrainedExecution;

namespace neetcode.LinkedList;
public static class CopyList
{
    // t: O(n)
    // S: O(1)
    public static ListNode? CopyDirty(ListNode? root)
    {
        ListNode? head = root, newHead = null!, cur = root, prev = null!;
        while (cur != null)
        {
            ListNode copy = new(cur.val);
            if (newHead is null)
            {
                newHead = copy;
                prev = copy;
            }
            else
            {
                prev.next = copy;
                prev = prev.next;
            }

            cur = cur.next;
        }

        return newHead;
    }

    // t: O(n) :: recursive function | for each node in we copy.
    // s: O(n) :: n pushes to the stack for recursive calls.
    public static ListNode? CopyRecursion(ListNode? root)
    {
        if (root is null)
            return null!;

        return new ListNode(root.val)
        {
            next = CopyRecursion(root.next)
        };
    }

    // t: O(n) :: Iterate though LL, we just handle the first iteration explicitly outside the loop.
    // s: O(1) :: Linear space.
    public static ListNode? CopyHandleHeadFirst(ListNode? root)
    {
        if (root is null)
            return null!;

        ListNode? newHead = new(root.val), tail = newHead, cur = root.next; // Handle first iteration inline.
        while (cur != null)
        {
            tail.next = new(cur.val);
            cur = cur.next;
            tail = tail.next;
        }

        return newHead;
    }

    // t: O(n) :: Iterate though LL, we just handle edge cases with sentinel node.
    // s: O(1) :: Linear space.
    public static ListNode? CopyWithDummyNode(ListNode? root)
    {
        if (root is null)
            return null!;

        ListNode? sentinel = new(0), tail = sentinel, cur = root; // Create a dummySentinel that initializes prev and tracks the newHead (sentinel.next).
        while (cur != null)
        {
            var copy = new ListNode(cur.val);
            tail.next = copy; // Whole point of tail is just to link up tail.next 
            tail = copy; // ... as soon as you link it just move it forward.

            cur = cur.next;
        }

        return sentinel.next;
    }
}
