namespace neetcode.Trees;
public static class BinaryTreeRightSideView
{
    public static List<int> RightSideViewDepthFirstSearch(TreeNode root)
    {
        List<int> res = new();

        if (root == null)
            return res;

        void Dfs(TreeNode? cur, int level)
        {
            if (cur is null)
                return;

            if (level == res.Count)
            {
                res.Add(cur.val);
            }

            Dfs(cur.right, level + 1);
            Dfs(cur.left, level + 1);
        }

        Dfs(root, 0);

        return res;
    }
}
