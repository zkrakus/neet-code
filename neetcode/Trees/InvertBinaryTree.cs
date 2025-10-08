namespace neetcode.Trees;
public class InvertBinaryTree
{
    public static TreeNode? InvertTreeDfs(TreeNode? root)
    {
        if (root is null) return root;

        void TreeTraverseInvertDfs(TreeNode node)
        {
            if (node is null) return;

            TreeTraverseInvertDfs(node.left);
            TreeTraverseInvertDfs(node.right);

            (node.left, node.right) = (node.right, node.left);
        }

        TreeTraverseInvertDfs(root);

        return root;
    }

    public static TreeNode? InvertTreeBfs(TreeNode? root)
    {
        if (root is null) return root;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            if (cur is null) continue;

            queue.Enqueue(cur.left);
            queue.Enqueue(cur.right);

            (cur.left, cur.right) = (cur.right, cur.left);
        }

        return root;
    }

    public TreeNode? InvertTreeNonRecursiveDFS(TreeNode? root)
    {
        if (root == null)
            return null;

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            // Swap left and right
            (current.left, current.right) = (current.right, current.left);

            if (current.left != null)
                stack.Push(current.left);
            if (current.right != null)
                stack.Push(current.right);
        }

        return root;
    }
}
