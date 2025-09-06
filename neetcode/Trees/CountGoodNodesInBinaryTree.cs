namespace neetcode.Trees;
public static class CountGoodNodesInBinaryTree
{
    public static int GoodNodesDepthFirstSearch(TreeNode root)
    {
        int count = 0;
        if (root == null) 
            return count;


        int DfsTreeCount(TreeNode? node, int max = int.MinValue)
        {
            if (node == null)
                return 0 ;

            var res = node.val >= max ? 1 : 0;
            max = Math.Max(max, node.val);

            res += DfsTreeCount(node?.left, max);
            res += DfsTreeCount(node?.right, max);

            return res;
        }

        count = DfsTreeCount(root);

        return count;
    }

    public static int GoodNodesBreadthFirstSearch(TreeNode root)
    {

    }
}