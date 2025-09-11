namespace neetcode.Trees;
public static class ValidBinarySearchTree
{
    public static bool IsValidBST(TreeNode root)
    {
        bool ValidateBst(TreeNode? node, int min = int.MinValue, int max = int.MaxValue)
        {
            if (node is null)
                return true;

            if (node.val <= min || node.val >= max)
                return false;

            return ValidateBst(node.left, min, node.val) && ValidateBst(node.right, node.val, max);
        }

        return IsValidBST(root);
    }
}
