namespace neetcode.Backtracking;
public static class CombinationSum
{
    public static List<List<int>> DoCombinationSum(int[] nums, int target)
    {
        List<List<int>> result = new();
        List<int> combination = new();

        void DFS(int i, int total)
        {
            if(total == target)
            {
                result.Add(new List<int>(combination));
                return;
            }

            if (i >= nums.Length || total > target)
            {
                return;
            }

            combination.Add(nums[i]);
            DFS(i, total + nums[i]);

            combination.RemoveAt(combination.Count - 1);
            DFS(i + 1, total);
        }

        DFS(0, 0);

        return result;
    }

}
