namespace neetcode.OneDimensionalDynamicProgramming;
public static class HouseRobber
{
    public static int Rob(int[] nums)
    {
        if (nums is null || nums.Length == 0) return 0;
        Dictionary<int, int> dp = new();

        int RobRec(int cur)
        {
            if (cur >= nums.Length) return 0;
            if (dp.TryGetValue(cur, out int cache)) return cache;

            var max = Math.Max(nums[cur] + RobRec(cur + 2), RobRec(cur + 1));
            dp[cur] = max;

            return max;
        }

        return RobRec(0);
    }
}
