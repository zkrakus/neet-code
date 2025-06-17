using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Backtracking;
public static class Subsets2
{
    public static List<List<int>> SubsetsWithDup(int[] nums)
    {
        if (nums is null)
            return new List<List<int>>() { };

        List<int> numsCopy = nums.ToList();
        numsCopy.Sort();
        List<List<int>> result = new();
        List<int> subset = new();
        void Backtrack(int i = 0)
        {
            if (i >= numsCopy.Count)
            {
                result.Add(subset.ToList());
                return;
            }

            subset.Add(numsCopy[i]);
            Backtrack(i + 1);

            subset.RemoveAt(subset.Count - 1);
            while (i + 1 < numsCopy.Count && numsCopy[i] == numsCopy[i + 1]) i++;

            Backtrack(i + 1);
        }

        Backtrack();

        return result;
    }
}
