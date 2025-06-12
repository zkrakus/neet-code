namespace neetcode.Backtracking;
public static class CombinationSum
{
    public static List<List<int>> DoCombinationSum(int[] nums, int target)
    {
        List<List<int>> result = new() { };
        if (nums is null || nums.Length == 0)
            return result;

        List<int> combination = new();
        void SumRec(int i = 0, int total = 0)
        {
            if (total == target)
            {
                result.Add(combination.ToList());
                return;
            }

            if (i == nums.Length || total > target)
                return;

            // Include nums[i]
            combination.Add(nums[i]);
            SumRec(i, total + nums[i]);
            
            // Excluse nums[i]
            combination.RemoveAt(combination.Count - 1);
            SumRec(i + 1, total);
        }

        SumRec();

        return result;
    }
}
