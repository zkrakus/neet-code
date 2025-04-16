
using neetcode.Trees;

namespace Test.Trees;
public class DiameterOfBinaryTreeTests
{
    [Fact]
    public void FindDiameter_NullRoot_ReturnsZero()
    {
        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(null);
        Assert.Equal(0, result);
    }

    [Fact]
    public void FindDiameter_SingleNode_ReturnsZero()
    {
        var root = new TreeNode(1);
        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(0, result); // Diameter is number of edges, so 0 for single node
    }

    [Fact]
    public void FindDiameter_TwoNodes_ReturnsOne()
    {
        var root = new TreeNode(1, new TreeNode(2));
        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(1, result);
    }

    [Fact]
    public void FindDiameter_BalancedTree_ReturnsCorrectDiameter()
    {
        //        1
        //       / \
        //      2   3
        //     / \
        //    4   5
        //
        // Diameter is the path: 4 -> 2 -> 5 = 2 edges OR 4 -> 2 -> 1 -> 3 = 3 edges
        var root = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5)),
            new TreeNode(3));

        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(3, result);
    }

    [Fact]
    public void FindDiameter_UnbalancedTree_ReturnsCorrectDiameter()
    {
        //      1
        //     /
        //    2
        //   /
        //  3
        //   \
        //    4
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3, null, new TreeNode(4))));

        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(3, result); // Longest path: 4 -> 3 -> 2 -> 1
    }

    [Fact]
    public void FindDiameter_PerfectBinaryTreeDepth3_ReturnsCorrectDiameter()
    {
        //        1
        //       / \
        //      2   3
        //     / \ / \
        //    4  5 6  7
        //
        // Diameter: 4 -> 2 -> 1 -> 3 -> 7 = 4 edges
        var root = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5)),
            new TreeNode(3, new TreeNode(6), new TreeNode(7)));

        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(4, result);
    }

    [Fact]
    public void FindDiameter_ChainToTheRight_ReturnsCorrectDiameter()
    {
        // 1 - 2 - 3 - 4 - 5
        var root = new TreeNode(1, null,
            new TreeNode(2, null,
                new TreeNode(3, null,
                    new TreeNode(4, null,
                        new TreeNode(5)))));

        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(4, result);
    }

    [Fact]
    public void FindDiameter_TreeWithMultipleEqualLengthPaths_ReturnsCorrectDiameter()
    {
        //         1
        //        / \
        //       2   3
        //      /     \
        //     4       5
        //            /
        //           6
        //
        // Diameter is: 4 -> 2 -> 1 -> 3 -> 5 -> 6 = 5 edges
        var root = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), null),
            new TreeNode(3, null, new TreeNode(5, new TreeNode(6), null)));

        var solver = new DiameterOfBinaryTree();
        var result = solver.FindDiameter(root);
        Assert.Equal(5, result);
    }
}