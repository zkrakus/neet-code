using neetcode.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Trees;
public class MaximumDepthOfBinaryTreeTests
{
    [Fact]
    public void MaxDepth_NullRoot_ReturnsZero()
    {
        var solver = new MaximumDepthOfBinaryTree();
        var result = solver.MaxDepth(null);
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxDepth_SingleNode_ReturnsOne()
    {
        var root = new TreeNode(1);
        var solver = new MaximumDepthOfBinaryTree();

        var result = solver.MaxDepth(root);
        Assert.Equal(1, result);
    }

    [Fact]
    public void MaxDepth_PerfectBinaryTree_ReturnsCorrectDepth()
    {
        // Depth = 3
        //       1
        //      / \
        //     2   3
        //    / \ / \
        //   4  5 6  7
        var root = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5)),
            new TreeNode(3, new TreeNode(6), new TreeNode(7)));

        var solver = new MaximumDepthOfBinaryTree();
        var result = solver.MaxDepth(root);
        Assert.Equal(3, result);
    }

    [Fact]
    public void MaxDepth_LeftSkewedTree_ReturnsCorrectDepth()
    {
        // Depth = 4
        //   1
        //  /
        // 2
        //  \
        //   3
        //    \
        //     4
        var root = new TreeNode(1,
            new TreeNode(2,
                null,
                new TreeNode(3,
                    null,
                    new TreeNode(4))));

        var solver = new MaximumDepthOfBinaryTree();
        var result = solver.MaxDepth(root);
        Assert.Equal(4, result);
    }

    [Fact]
    public void MaxDepth_RightSkewedTree_ReturnsCorrectDepth()
    {
        // Depth = 3
        // 1
        //  \
        //   2
        //    \
        //     3
        var root = new TreeNode(1, null,
            new TreeNode(2, null,
                new TreeNode(3)));

        var solver = new MaximumDepthOfBinaryTree();
        var result = solver.MaxDepth(root);
        Assert.Equal(3, result);
    }

    [Fact]
    public void MaxDepth_UnbalancedTree_ReturnsCorrectDepth()
    {
        // Depth = 4
        //     1
        //    /
        //   2
        //  / \
        // 3   4
        //        \
        //         5
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3),
                new TreeNode(4, null, new TreeNode(5))));

        var solver = new MaximumDepthOfBinaryTree();
        var result = solver.MaxDepth(root);
        Assert.Equal(4, result);
    }
}