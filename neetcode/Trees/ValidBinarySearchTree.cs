namespace neetcode.Trees;
public static class ValidBinarySearchTree
{
    public static bool IsValidBstDfs(TreeNode root)
    {
        bool ValidateBst(TreeNode? node, int min = int.MinValue, int max = int.MaxValue)
        {
            if (node is null)
                return true;

            if (node.val <= min || node.val >= max)
                return false;

            return ValidateBst(node.left, min, node.val) && ValidateBst(node.right, node.val, max);
        }

        return ValidateBst(root);
    }

    public static bool IsValidBstBfs(TreeNode root)
    {
        if (root is null)
            return true;

        Queue<(TreeNode node, int min, int max)> bfsQueue = new();
        bfsQueue.Enqueue((root, int.MinValue, int.MaxValue));


        while (bfsQueue.Count != 0)
        {
            var (node, min, max) = bfsQueue.Dequeue();

            if (node.val <= min || node.val >= max)
                return false;

            if (node.left != null)
                bfsQueue.Enqueue((node.left, min, node.val));
            if (node.right!= null)
                bfsQueue.Enqueue((node.right, node.val, max));
        }

        return true;
    }
}
