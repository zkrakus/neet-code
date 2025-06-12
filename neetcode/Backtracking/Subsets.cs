using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Backtracking;
public static class Subsets
{
    public static List<List<int>>? FindSubsets(int[] nums)
    {
        if (nums is null)
            return null;

        List<List<int>> result = new List<List<int>>();
        List<int> subset = new List<int>();
        void FindSubsetsRec(int i, List<int> subset)
        {
            if (i == nums.Length)
            {
                result.Add(subset.ToList());
                return;
            }

            subset.Add(nums[i]);
            FindSubsetsRec(i + 1, subset);
            subset.RemoveAt(subset.Count - 1);
            FindSubsetsRec(i + 1, subset);
        }

        FindSubsetsRec(0, subset);

        return result;
    }
}
