using neetcode.Trees;

namespace Test.Trees;
public class SameBinaryTreeTests
{
    [Fact]
    public void IsSameTree_BothTreesAreNull_ReturnsFalse()
    {
        // Arrange
        TreeNode? p = null;
        TreeNode? q = null;

        // Act
        var result = SameBinaryTree.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSameTree_OneTreeIsNull_ReturnsFalse()
    {
        // Arrange
        var p = new TreeNode(1);
        TreeNode? q = null;

        // Act
        var result = SameBinaryTree.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSameTree_IdenticalSingleNodeTrees_ReturnsTrue()
    {
        // Arrange
        var p = new TreeNode(1);
        var q = new TreeNode(1);

        // Act
        var result = SameBinaryTree.IsSameTree(p, q);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSameTree_DifferentStructure_ReturnsFalse()
    {
        // Arrange
        var p = new TreeNode(1)
        {
            left = new TreeNode(2)
        };

        var q = new TreeNode(1)
        {
            right = new TreeNode(2)
        };

        // Act
        var result = SameBinaryTree.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSameTree_SameStructureAndValues_ReturnsTrue()
    {
        // Arrange
        var p = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        var q = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        // Act
        var result = SameBinaryTree.IsSameTree(p, q);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSameTree_SameStructureDifferentValues_ReturnsFalse()
    {
        // Arrange
        var p = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        var q = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(4)
        };

        // Act
        var result = SameBinaryTree.IsSameTree(p, q);

        // Assert
        Assert.False(result);
    }
}