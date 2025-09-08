using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.LinkedList;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode? other; // Use as an arbitrary second pointer as needed.
    public ListNode(int val = 0, ListNode? next = null, ListNode? other = null)
    {
        this.val = val;
        this.next = next;
        this.other = other;
    }
}