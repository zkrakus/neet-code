using neetcode.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Trees;
public class InvertBinaryTreeTests
{
    [Fact]
    public void InvertTree_NullRoot_ReturnsNull()
    {
        var inverter = new InvertBinaryTree();
        TreeNode? result = inverter.InvertTree(null);
        Assert.Null(result);
    }

    [Fact]
    public void InvertTree_SingleNode_ReturnsSameNode()
    {
        var root = new TreeNode(1);
        var inverter = new InvertBinaryTree();

        var result = inverter.InvertTree(root);

        Assert.Equal(1, result!.val);
        Assert.Null(result.left);
        Assert.Null(result.right);
    }

    [Fact]
    public void InvertTree_FullBinaryTree_InvertsCorrectly()
    {
        // Original tree:
        //     1
        //    / \
        //   2   3
        //  / \ / \
        // 4  5 6  7
        var root = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5)),
            new TreeNode(3, new TreeNode(6), new TreeNode(7)));

        var inverter = new InvertBinaryTree();
        var result = inverter.InvertTree(root);

        // Expected inverted tree:
        //     1
        //    / \
        //   3   2
        //  / \ / \
        // 7  6 5  4

        Assert.Equal(1, result!.val);
        Assert.Equal(3, result.left!.val);
        Assert.Equal(2, result.right!.val);

        Assert.Equal(7, result.left.left!.val);
        Assert.Equal(6, result.left.right!.val);
        Assert.Equal(5, result.right.left!.val);
        Assert.Equal(4, result.right.right!.val);
    }

    [Fact]
    public void InvertTree_LeftHeavyTree_InvertsCorrectly()
    {
        //     1
        //    /
        //   2
        //  /
        // 3
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3)));

        var inverter = new InvertBinaryTree();
        var result = inverter.InvertTree(root);

        // Expected:
        //     1
        //      \
        //       2
        //        \
        //         3
        Assert.Equal(1, result!.val);
        Assert.Null(result.left);
        Assert.Equal(2, result.right!.val);
        Assert.Null(result.right.left);
        Assert.Equal(3, result.right.right!.val);
    }

    [Fact]
    public void InvertTree_RightHeavyTree_InvertsCorrectly()
    {
        // 1
        //  \
        //   2
        //    \
        //     3
        var root = new TreeNode(1, null,
            new TreeNode(2, null,
                new TreeNode(3)));

        var inverter = new InvertBinaryTree();
        var result = inverter.InvertTree(root);

        // Expected:
        //     1
        //    /
        //   2
        //  /
        // 3
        Assert.Equal(1, result!.val);
        Assert.Equal(2, result.left!.val);
        Assert.Null(result.right);
        Assert.Equal(3, result.left.left!.val);
    }
}