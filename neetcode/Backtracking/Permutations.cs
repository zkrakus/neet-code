using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Backtracking;
public static class Permutations
{
    public static List<List<int>> Permute(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return new List<List<int>>();

        var permutations = Permute(nums[1..]);
        var result = new List<List<int>>();
        foreach (var permutation in permutations)
        {
            for (int i = 0; i <= permutation.Count; i++)
            {
                var p_copy = permutation.ToList();
                p_copy.Insert(i, nums[0]);
                result.Add(p_copy);
            }
        }

        return result;
    }
}
