using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace neetcode.OneDimensionalDynamicProgramming;
public static class MinConstClimbingStairs
{
    public static int MinCost(int[] cost)
    {
        if (cost == null || cost.Length == 0) return 0;
        Dictionary<int, int> dp = new();

        int MinCostRecur(int cur)
        {
            if (cur >= cost.Length) return 0; // Once you pass the last step, cost is 0
            if (dp.TryGetValue(cur, out int cached)) return cached;

            var min = cost[cur] + Math.Min(MinCostRecur(cur + 1), MinCostRecur(cur + 2));
            dp[cur] = min;

            return min;
        }

        return Math.Min(MinCostRecur(0), MinCostRecur(1));
    }


    public static int MinCostRec(int[] cost)
    {
        if (cost is null || cost.Length == 0) return 0;

        int MinCostRecurrenceFunction(int cur)
        {
            if (cur >= cost.Length) return 0;

            return cost[cur] + Math.Min(MinCostRecurrenceFunction(cur + 2), MinCostRecurrenceFunction(cur + 1));
        }

        return Math.Min(MinCostRecurrenceFunction(1), MinCostRecurrenceFunction(0));
    }
}
