using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.OneDimensionalDynamicProgramming;
public static class ClimbingStairs
{
    public static int ClimbStairs(int n)
    {
        if (n < 0)
            return 0;
        if (n == 0)
            return 1;
        if (n == 1)
            return 1;

        int nMinus1 = 1;
        int nMinus2 = 1;
        for (int i = 2; i <= n; i++)
        {
            var tmp = nMinus1;
            nMinus1 += nMinus2;
            nMinus2 = tmp;
        }

        return nMinus1;
    }

    public static int ClimbStairsBrute(int n)
    {
        if (n < 0)
            return 0;

        static int ClimbStairsRecursive(int cur, int n)
        {
            if (cur == n) return 1;
            if (cur > n) return 0;

            return ClimbStairsRecursive(cur + 1, n) + ClimbStairsRecursive(cur + 2, n);
        }

        return ClimbStairsRecursive(1, n) + ClimbStairsRecursive(2, n);
    }

    public static int ClimbMemoized(int n)
    {
        if (n < 0)
            return 0;

        Dictionary<int, int> dp = new();
        int ClimbMemoizedRecursive(int n, int cur, Dictionary<int, int> dp)
        {
            if (cur > n) return 0;
            if (cur == n) return 1;
            if (dp.TryGetValue(cur, out var output)) return output;

            dp[cur] = ClimbMemoizedRecursive(n, cur + 1, dp) + ClimbMemoizedRecursive(n, cur + 2, dp);

            return dp[cur];
        }

        return ClimbMemoizedRecursive(n, 0, dp);
    }
}
