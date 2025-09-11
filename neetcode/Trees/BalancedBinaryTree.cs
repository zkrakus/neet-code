using System;

namespace neetcode.Trees;
public static class BalancedBinaryTree
{
    //public static bool IsBalanced(TreeNode? root)
    //{
    //    if (root is null)
    //        return true;

    //    var height = 0;
    //    var leftHeight = DFSHeight(root.left, height);
    //    var rightHeight = DFSHeight(root.right, height);

    //    if (!leftHeight.balanced || !rightHeight.balanced)
    //        return false;

    //    var heightDifference = Math.Abs(rightHeight.height - leftHeight.height);
    //    if (heightDifference > 1)
    //        return false;
    //    else
    //        return true;
    //}

    //private static (int height, bool balanced) DFSHeight(TreeNode? node, int height)
    //{
    //    if (node is null)
    //        return (height, true);

    //    height++;

    //    var leftHeight = DFSHeight(node.left, height);
    //    var rightHeight = DFSHeight(node.right, height);
    //    var maxheight = Math.Max(leftHeight.height, rightHeight.height);

    //    if (!leftHeight.balanced || !rightHeight.balanced)
    //        return (height, false);

    //    var heightDifference = Math.Abs(rightHeight.height - leftHeight.height);
    //    if (heightDifference > 1)
    //        return (maxheight, false);
    //    else
    //        return (maxheight, true);
    //}

    public static bool IsBalanced(TreeNode? root)
    {
        bool isBalanced = true;
        int IsBalancedRec(TreeNode? node, int depth)
        {
            if (node == null || isBalanced == false)
                return 0;

            var ld = IsBalancedRec(node.left, depth);
            var rd = IsBalancedRec(node.right, depth);

            if (Math.Abs(ld - rd) > 1)
                isBalanced = false;

            var greaterDepth = Math.Max(ld, rd);

            return ++greaterDepth;
        }

        _ = IsBalancedRec(root, 0);

        return isBalanced;
    }
}
