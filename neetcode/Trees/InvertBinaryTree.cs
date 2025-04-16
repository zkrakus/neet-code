namespace neetcode.Trees;
public class InvertBinaryTree
{
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root == null)
            return root;

        var left = InvertTree(root.left);
        var right = InvertTree(root.right);

        root.left = right;
        root.right = left;

        return root;
    }

    public TreeNode? InvertTreeNonRecursiveBFS(TreeNode? root)
    {
        if (root == null)
            return null;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            // swap
            (current.left, current.right) = (current.right, current.left);

            if (current.left != null)
                queue.Enqueue(current.left);
            if (current.right != null)
                queue.Enqueue(current.right);
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
