using System.Security.AccessControl;

namespace neetcode.Trees;
public static class SubtreeOfAnotherTree
{
    // Review this solution.
    public static bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        // Always true because a null subtree always exists as at least a leef in the main tree.
        if (subRoot is null)
            return true;

        // Contrapositive of the above. If the subtree has nodes, and the root doesn't ... then it's not a subtree.
        if (root is null && subRoot is not null)
            return false;


        if (SameBinaryTree(root, subRoot))
            return true;

        return IsSubtree(root!.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    public static bool SameBinaryTree(TreeNode? s, TreeNode? t)
    {
        if (s is null && t is null)
            return true;

        if (s is not null && t is not null && s.val == t.val)
            return SameBinaryTree(s.left, t.left) && SameBinaryTree(s.right, t.right);


        return false;
    }
}
