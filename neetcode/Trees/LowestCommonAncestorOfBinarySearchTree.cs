using System.Xml.Linq;

namespace neetcode.Trees;
public static class LowestCommonAncestorOfBinarySearchTree
{
    public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        if (root is null || p is null || q is null)
            return null;

        // There is no constraint that states p will always be less than q.
        int qVal, pVal;
        if (p.val > q.val)
            (qVal, pVal) = (p.val, q.val);
        else
            (pVal, qVal) = (p.val, q.val);

        TreeNode? LCA(TreeNode node, int p, int q)
        {
            if (node.val == p || node.val == q)
                return node;
            else if (p < node.val && q > node.val)
                return node;

            if (p < node.val && q < node.val)
                return LCA(node?.left, p, q);
            else
                return LCA(node?.right, p, q);
        }

        return LCA(root, pVal, qVal);
    }
}
