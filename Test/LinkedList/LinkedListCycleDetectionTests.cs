using neetcode.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.LinkedList;
public class LinkedListCycleDetectionTests
{

    [Fact]
    public void HasCycle_SingleNodeNoCycle_ReturnsFalse()
    {
        var node = new ListNode(1);
        Assert.False(LinkedListCycleDetection.HasCycle(node));
    }

    [Fact]
    public void HasCycle_TwoNodesNoCycle_ReturnsFalse()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        node1.next = node2;

        Assert.False(LinkedListCycleDetection.HasCycle(node1));
    }

    [Fact]
    public void HasCycle_TwoNodesCycle_ReturnsTrue()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        node1.next = node2;
        node2.next = node1;

        Assert.True(LinkedListCycleDetection.HasCycle(node1));
    }

    [Fact]
    public void HasCycle_MultipleNodesCycleAtStart_ReturnsTrue()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node1;

        Assert.True(LinkedListCycleDetection.HasCycle(node1));
    }

    [Fact]
    public void HasCycle_MultipleNodesCycleInMiddle_ReturnsTrue()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);
        var node5 = new ListNode(5);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;
        node5.next = node3;

        Assert.True(LinkedListCycleDetection.HasCycle(node1));
    }

    [Fact]
    public void HasCycle_MultipleNodesNoCycle_ReturnsFalse()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        var node3 = new ListNode(3);
        var node4 = new ListNode(4);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;

        Assert.False(LinkedListCycleDetection.HasCycle(node1));
    }
}