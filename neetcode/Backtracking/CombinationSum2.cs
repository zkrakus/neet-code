using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Backtracking;
public static class CombinationSum2
{
    public static List<List<int>> DoCombinationSum2(int[] nums, int target)
    {
        if (nums is null || nums.Length == 0 || target <= 0)
            return new List<List<int>>();

        var numsCopy = nums.ToArray();
        Array.Sort(numsCopy);

        var result = new List<List<int>>();
        var combination = new List<int>();

        void DFS(int i = 0, int total = 0)
        {
            if (total == target)
            {
                result.Add(combination.ToList());
                return;
            }

            if (numsCopy.Length == i || total > target)
                return;

            combination.Add(numsCopy[i]);
            DFS(i + 1, total + numsCopy[i]);

            while (i + 1 < numsCopy.Length && numsCopy[i + 1] == numsCopy[i]) i++;

            combination.RemoveAt(combination.Count - 1);
            DFS(i + 1, total);
        }

        DFS();

        return result;
    }
}
