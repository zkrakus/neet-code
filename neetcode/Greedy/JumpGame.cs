using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

    // t: O(n^2)
    // s: O(n)
    public static bool CanJumpDyanmicProgrammingTopDown(int[] nums)
    {
        if (nums is null) return false;
        if (nums.Length == 0) return true;

        Dictionary<int, bool> memo = new();
        bool dfs(int cur)
        {
            if (memo.TryGetValue(cur, out bool value))
                return value;

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

    // O : (n^2)
    // O : (n)
    public static bool CanJumpDyanmicProgrammingBottomUp(int[] nums)
    {
        if (nums is null) return false;
        if (nums.Length == 0) return true;

        int n = nums.Length;
        bool[] dp = new bool[n];
        dp[n - 1] = true; // Trivial success case. You got to the last position. All other indices will be judged by whether they can hop into some dp[j] == true slot.

        for (int i = n - 2; i >= 0; i--) // Start at n - 2 because n - 1 is the trivial success case. Moving backwards guarantees that every j > i has already been evaluated, so dp[j] is ready to consult.
        {
            int end = Math.Min(n, i + nums[i]);
            for (int j = i + 1; j <= end; j++) {
                if (dp[j])
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[0];
    }


    public static bool CanJump(int[] nums)
    {
        bool CanJumpDfs(int i)
        {
            if (i == nums.Length) return false;
            if (i == nums.Length - 1) return true;

            var boundary = Math.Min(nums[i], nums.Length - 1);
            for(int j = boundary; j > 0; j--)
                if (CanJumpDfs(i + j))
                    return true;

            return false;
        }

        return CanJumpDfs(0);
    }
}
