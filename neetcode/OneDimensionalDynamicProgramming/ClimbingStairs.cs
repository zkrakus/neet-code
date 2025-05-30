using System;
using System.Collections.Generic;
using System.Linq;
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
        for (int i = 2; i <= n; i ++)
        {
            var tmp = nMinus1;
            nMinus1 += nMinus2;
            nMinus2 = tmp;
        }

        return nMinus1;
    }

    public static int ClimbStairsBrute(int n)
    {
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
        Dictionary<int, int> dp = new();
        return ClimbStairsMemoizedRecursive(0, n, dp);
    }

    public static int ClimbStairsMemoizedRecursive(int cur, int n, Dictionary<int, int> dp)
    {
        if (cur == n) return 1;
        if (cur > n) return 0;

        if (dp.TryGetValue(cur, out int value))
            return value;

        int result = ClimbStairsMemoizedRecursive(cur + 1, n, dp)
               + ClimbStairsMemoizedRecursive(cur + 2, n, dp);

        dp[cur] = result;
        return result;
    }
}
