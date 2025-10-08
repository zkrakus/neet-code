namespace neetcode.Trees;
public static class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    //public static TreeNode BuildTree(int[] preorder, int[] inorder)
    //{
    //    TreeNode inorderRoot = null;
    //    int BuildTreePreOrder(int cur)
    //    {
    //        if (cur >= preorder.Length)
    //            return cur;

    //        TreeNode treeNode = new TreeNode(preorder[cur]);
    //        cur = BuildTreePreOrder(cur + 1);
    //        cur = BuildTreePreOrder(cur + 1);

    //        return cur;
    //    }

    //    BuildTreePreOrder(0);
    //}


    //public static TreeNode BuildTree(int[] preorder, int[] inorder)
    //{
    //    int pre_idx = 0;
    //    Dictionary<int, int> indexDictionary = new Dictionary<int, int>();

    //    for (int i = 0; i < inorder.Length; i++)
    //    {
    //        indices[inorder[i]] = i;
    //    }

    //    TreeNode Dfs(int[] preorder, int l, int r)
    //    {
    //        if (l > r) return null;
    //        int root_val = preorder[pre_idx++];
    //        TreeNode root = new TreeNode(root_val);
    //        int mid = indices[root_val];
    //        root.left = Dfs(preorder, l, mid - 1);
    //        root.right = Dfs(preorder, mid + 1, r);
    //        return root;
    //    }

    //    return Dfs(preorder, 0, inorder.Length - 1);
    //}
}
