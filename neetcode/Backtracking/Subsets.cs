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
    public static List<List<int>> FindSubsets(int[] nums)
    {
        List<List<int>> result = new();
        List<int> subset = new();

        // Start building all subsets starting from index 0;
        DepthFirstSearch(0);

        return result;

        void DepthFirstSearch(int i)
        {
            // All decisions (include/exclude) have been made for each element — save the current subset.
            if (i >= nums.Length)
            {
                result.Add(new List<int>(subset));
                return;
            }

            // Include nums[i] in the subset.
            subset.Add(nums[i]);
            // Recurse to process the next index.
            DepthFirstSearch(i + 1);

            // Backtrack: remove the previously included element.
            subset.RemoveAt(subset.Count - 1);

            // Recurse without including nums[i] in the subset.
            DepthFirstSearch(i + 1);
        }
    }
}
