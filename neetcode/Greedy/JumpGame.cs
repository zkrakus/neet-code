using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Greedy;
public static class JumpGame
{
    // t : O(n!)
    // s : O(n)
    public static bool CanJumpRecursion(int[] nums)
    {
        if (nums is null) return false;
        if (nums.Length == 0) return true;

        bool dfs(int cur)
        {
            if (cur >= nums.Length || nums[cur] == 0)
                return false;

            int end = Math.Min(nums.Length - 1, cur + nums[cur]);
            for (int i = cur + 1; i <= end; i++)
            {
                if (dfs(i))
                    return true;
            }

            return false;
        }

        return dfs(0);
    }


    public static bool CanJumpDyanmicProgrammingTopDown(int[] nums)
    {
        if (nums is null) return false;
        if (nums.Length == 0) return true;

        Dictionary<int, bool> memo = new();
        bool dfs(int cur)
        {
            if (memo.ContainsKey(cur))
                return memo[cur];

            if (cur >= nums.Length || nums[cur] == 0)
                return false;

            int end = Math.Min(nums.Length - 1, cur + nums[cur]);
            for (int i = cur + 1; i <= end; i++)
            {
                if (dfs(i))
                {
                    memo[cur] = true;
                    return true;
                }
            }

            memo[cur] = false;
            return false;
        }

        return dfs(0);
    }
}
