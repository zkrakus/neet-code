using neetcode.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Trees;
public class SubtreeOfAnotherTreeTests
{
    [Fact]
    public void SubRoot_Is_Subtree_Of_Root_ShouldReturnTrue()
    {
        var root = new TreeNode(3,
            new TreeNode(4, new TreeNode(1), new TreeNode(2)),
            new TreeNode(5));

        var subRoot = new TreeNode(4, new TreeNode(1), new TreeNode(2));

        bool result = SubtreeOfAnotherTree.IsSubtree(root, subRoot);

        Assert.True(result);
    }

    [Fact]
    public void SubRoot_Is_Not_Subtree_Of_Root_ShouldReturnFalse()
    {
        var root = new TreeNode(3,
            new TreeNode(4, new TreeNode(1), new TreeNode(2, new TreeNode(0))),
            new TreeNode(5));

        var subRoot = new TreeNode(4, new TreeNode(1), new TreeNode(2));

        bool result = SubtreeOfAnotherTree.IsSubtree(root, subRoot);

        Assert.False(result);
    }

    [Fact]
    public void Root_And_SubRoot_BothNull_ShouldReturnTrue()
    {
        bool result = SubtreeOfAnotherTree.IsSubtree(null, null);

        Assert.True(result);
    }

    [Fact]
    public void SubRoot_IsNull_Root_NotNull_ShouldReturnTrue()
    {
        var root = new TreeNode(1);

        bool result = SubtreeOfAnotherTree.IsSubtree(root, null);

        Assert.True(result);
    }

    [Fact]
    public void Root_IsNull_SubRoot_NotNull_ShouldReturnFalse()
    {
        var subRoot = new TreeNode(1);

        bool result = SubtreeOfAnotherTree.IsSubtree(null, subRoot);

        Assert.False(result);
    }
}
