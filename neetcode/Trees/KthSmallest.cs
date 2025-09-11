namespace neetcode.Trees;
public static class KthSmallest
{
    public static int FindInOrderTraversalUsingDepth(TreeNode root, int k)
    {
        int smallest = int.MaxValue;
        int TreeInOrderTraversal(TreeNode node, int kth)
        {
            if (node is null)
                return kth;

            kth = TreeInOrderTraversal(node.left, kth);
            if (kth >= k) 
                return kth;

            smallest = node.val;
            kth++;
            if (kth >= k) 
                return kth;

            return TreeInOrderTraversal(node.right, kth);
        }

        TreeInOrderTraversal(root, 0);

        return smallest;
    }

    public static int FindInOrderTraversalWithBetterConditions(TreeNode root, int k)
    {
        int count = 0, result = -1;
        bool InOrderTraversal(TreeNode node)
        {
            if (node is null) 
                return false;
            if (InOrderTraversal(node.left)) 
                return true;

            count++;
            if (count == k) { 
                result = node.val; 
                return true; 
            }

            return InOrderTraversal(node.right);
        }

        InOrderTraversal(root);

        return result;
    }
}
