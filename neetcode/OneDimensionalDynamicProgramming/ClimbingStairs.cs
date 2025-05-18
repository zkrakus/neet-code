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
        int one = 1, two = 1;

        for (int i = 0; i < n; i++) {
            var tmp = one;
            one = one + two;
            two = tmp;
        }

        return one;
    }

    public static int ClimbStairsBrute(int n)
    {
        int result1 = ClimbStairsRecursive(0, 1, n);
        int result2 = ClimbStairsRecursive(0, 2, n);

        return result1 + result2;
    }

    public static int ClimbStairsRecursive(int cur, int steps, int n)
    {
        cur += steps;
        
        if (cur == n) return 1;
        if (cur > n) return 0;
        
        return ClimbStairsRecursive(cur, 1, n) + ClimbStairsRecursive(cur, 2, n);
        
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

        if (dp.ContainsKey(cur)) return dp[cur];

        int result = ClimbStairsMemoizedRecursive(cur + 1, n, dp)
               + ClimbStairsMemoizedRecursive(cur + 2, n, dp);

        dp[cur] = result;
        return result;
    }

    public static int ClimbStairsOptimal(int n)
    {
        int one = 1, two = 2;
        for(int i = 3; i <= n; i++)
        {
            var temp = one;
            one = one + two;
            two = temp;
        }

        return one;
    }
}
