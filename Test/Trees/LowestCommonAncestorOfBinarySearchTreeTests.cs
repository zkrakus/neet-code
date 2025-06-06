using neetcode.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Trees;
public class LowestCommonAncestorOfBinarySearchTreeTests
{
    [Fact]
    public void Returns_LCA_When_Nodes_Are_On_Opposite_Sides()
    {
        // Tree:
        //        6
        //       / \
        //      2   8
        //     / \ / \
        //    0  4 7  9
        //      / \
        //     3   5

        var root = new TreeNode(6,
            new TreeNode(2,
                new TreeNode(0),
                new TreeNode(4,
                    new TreeNode(3),
                    new TreeNode(5)
                )
            ),
            new TreeNode(8,
                new TreeNode(7),
                new TreeNode(9)
            )
        );

        var p = root.left!;        // Node 2
        var q = root.right!;       // Node 8

        var lca = LowestCommonAncestorOfBinarySearchTree.LowestCommonAncestor(root, p, q);
        Assert.Equal(6, lca!.val);
    }

    [Fact]
    public void Returns_LCA_When_One_Node_Is_Ancestor_Of_Another()
    {
        var root = new TreeNode(6,
            new TreeNode(2,
                new TreeNode(0),
                new TreeNode(4,
                    new TreeNode(3),
                    new TreeNode(5)
                )
            ),
            new TreeNode(8)
        );

        var p = root.left!;         // Node 2
        var q = root.left.right!;   // Node 4

        var lca = LowestCommonAncestorOfBinarySearchTree.LowestCommonAncestor(root, p, q);
        Assert.Equal(2, lca!.val);
    }

    [Fact]
    public void Returns_Same_Node_When_Both_Nodes_Are_Equal()
    {
        var root = new TreeNode(1);

        var p = root;
        var q = root;

        var lca = LowestCommonAncestorOfBinarySearchTree.LowestCommonAncestor(root, p, q);
        Assert.Equal(1, lca!.val);
    }

    [Fact]
    public void Returns_Null_When_Root_Is_Null()
    {
        TreeNode? root = null;

        var p = new TreeNode(1);
        var q = new TreeNode(2);

        var lca = LowestCommonAncestorOfBinarySearchTree.LowestCommonAncestor(root, p, q);
        Assert.Null(lca);
    }
}
