using neetcode.Trees;

namespace Test.Trees;

public class BalancedBinaryTreeTests
{
    [Fact]
    public void IsBalanced_NullRoot_ReturnsTrue()
    {
        TreeNode? root = null;
        var result = BalancedBinaryTree.IsBalanced(root);
        Assert.True(result);
    }

    [Fact]
    public void IsBalanced_SingleNode_ReturnsTrue()
    {
        var root = new TreeNode(1);
        var result = BalancedBinaryTree.IsBalanced(root);
        Assert.True(result);
    }

    [Fact]
    public void IsBalanced_PerfectlyBalancedTree_ReturnsTrue()
    {
        var root = new TreeNode(1,
                        new TreeNode(2,
                            new TreeNode(4),
                            new TreeNode(5)
                        ),
                        new TreeNode(3,
                            new TreeNode(6),
                            new TreeNode(7)
                        )
                    );

        var result = BalancedBinaryTree.IsBalanced(root);
        Assert.True(result);
    }

    [Fact]
    public void IsBalanced_LeftHeavyUnbalancedTree_ReturnsFalse()
    {
        var root = new TreeNode(1,
                        new TreeNode(2,
                            new TreeNode(3,
                                new TreeNode(4), null
                            ), null
                        ), null
                    );

        var result = BalancedBinaryTree.IsBalanced(root);
        Assert.False(result);
    }

    [Fact]
    public void IsBalanced_RightHeavyUnbalancedTree_ReturnsFalse()
    {
        var root = new TreeNode(1,
                        null,
                        new TreeNode(2,
                            null,
                            new TreeNode(3,
                                null,
                                new TreeNode(4)
                            )
                        )
                    );

        var result = BalancedBinaryTree.IsBalanced(root);
        Assert.False(result);
    }

    [Fact]
    public void IsBalanced_SmallBalancedTreeWithOneExtraNode_ReturnsTrue()
    {
        var root = new TreeNode(1,
                        new TreeNode(2),
                        new TreeNode(3,
                            new TreeNode(4), null
                        )
                    );

        var result = BalancedBinaryTree.IsBalanced(root);
        Assert.True(result);
    }
}