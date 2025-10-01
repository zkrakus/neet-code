namespace neetcode.OneDimensionalDynamicProgramming;
public static class HouseRobberII
{
    public static int MaxRob(int[] nums)
    {
        int n = nums.Length;
        int MaxRobDfs(int i, bool robbedFirst){
            if (i >= n || (i == n - 1 && robbedFirst))
                return 0;

            int rob = nums[i] + MaxRobDfs(i + 2, robbedFirst);
            int skip = MaxRobDfs(i + 1, robbedFirst);

            return Math.Max(skip, rob);
        }

        return Math.Max(MaxRobDfs(0, true), MaxRobDfs(0, false));
    }
}
