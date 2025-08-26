using System.Xml.Linq;

namespace neetcode.Trees;
public static class BinaryTreeLevelOrderTraversal
{
    public static List<List<int>> LevelOrderTraversalBFS(TreeNode root)
    {
        var res = new List<List<int>>();
        if (root is null) return res;

        var bfsQueue = new Queue<TreeNode?>();
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            List<int> level = new();
            for (int i = bfsQueue.Count; i > 0; i--)
            {
                var node = bfsQueue.Dequeue();
                if (node is null) continue;
                level.Add(node.val);
                bfsQueue.Enqueue(node?.left);
                bfsQueue.Enqueue(node?.right);
            }

            if (level.Any())
                res.Add(level);
        }

        return res;
    }

    public static List<List<int>> LevelOrderTraversalDFS(TreeNode root)
    {
        var res = new List<List<int>>();

        if (root is null)
            return res;

        void Dfs(TreeNode? cur, int depth)
        {
            if (cur is null)
                return;

            if (res.Count == depth)
                res.Add(new List<int>());

            res[depth].Add(cur.val);
            Dfs(cur.left, depth + 1);
            Dfs(cur.right, depth + 1);
        }

        Dfs(root, 0);

        return res;
    }
}
