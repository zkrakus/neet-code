namespace neetcode.Backtracking;
public static class Subsets
{
    public static List<List<int>>? FindSubsets(int[] nums)
    {
        if (nums is null)
            return null;

        List<List<int>> result = new();
        List<int> subset = new();
        void FindSubsetsRec(int i)
        {
            if (i == nums.Length)
            {
                result.Add(subset.ToList());
                return;
            }

            subset.Add(nums[i]);
            FindSubsetsRec(i + 1);
            subset.RemoveAt(subset.Count - 1);
            FindSubsetsRec(i + 1);
        }

        FindSubsetsRec(0);

        return result;
    }

    public static IList<IList<int>> SubsetsIterative(int[] nums)
    {
        var result = new List<IList<int>> { new List<int>() };

        foreach (int num in nums)
        {
            int count = result.Count;
            for (int i = 0; i < count; i++)
            {
                var newSubset = new List<int>(result[i]) { num };
                result.Add(newSubset);
            }
        }

        return result;
    }

    public static IList<IList<int>> SubsetsBacktracking(int[] nums)
    {
        var result = new List<IList<int>>();
        Backtrack(0, new List<int>());
        return result;

        void Backtrack(int start, List<int> path)
        {
            result.Add(new List<int>(path));

            for (int i = start; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                Backtrack(i + 1, path);
                path.RemoveAt(path.Count - 1); // undo step
            }
        }
    }
}
