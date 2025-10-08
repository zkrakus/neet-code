using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Trees;
public class MaximumDepthOfBinaryTree
{
    public int MaxDepth(TreeNode? root)
    {
        var depth = 1;

        if (root is null)
            return 0;
        else
            return Math.Max(TraverseTreeWithDepth(root.left, depth), TraverseTreeWithDepth(root.right, depth));
    }

    public int TraverseTreeWithDepth(TreeNode? node, int depth)
    {
        if (node is null) 
            return depth;
        
        depth++;

        return Math.Max(TraverseTreeWithDepth(node.left, depth), TraverseTreeWithDepth(node.right, depth));
    }

    public static int MaxDepthDfsPostOrder(TreeNode root)
    {
        int MaxDepthDfs(TreeNode node, int depth)
        {
            if (node is null) return depth;

            var maxDepth = Math.Max(MaxDepthDfs(node.left, depth + 1), MaxDepthDfs(node.right, depth + 1));

            return maxDepth;
        }

        return MaxDepthDfs(root, 0);
    }

    public static int MaxDepthDfsPostOrderSimpleArgs(TreeNode root)
    {
        int MaxDepthDfs(TreeNode node)
        {
            if (node is null) return 0;

            var maxDepth = Math.Max(MaxDepthDfs(node.left), MaxDepthDfs(node.right));

            return maxDepth + 1;
        }

        return MaxDepthDfs(root);
    }
}
