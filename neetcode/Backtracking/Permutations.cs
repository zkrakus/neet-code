using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Backtracking;
public static class Permutations
{
    public static List<List<int>> Permutes(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return new List<List<int>>();

        if(nums.Length == 1)
            return new List<List<int>>() { nums.ToList() };

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

    public static List<List<int>> Permute(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return new List<List<int>>();

        var perms = new List<List<int>>() { new List<int>() };
        foreach(var n in nums)
        {
            var new_perms = new List<List<int>>();
            foreach(var p in perms)
            {
                for(int i = 0; i <= p.Count; i++)
                {
                    var p_copy = p.ToList();
                    p_copy.Insert(i, n);
                    new_perms.Add(p_copy);
                }
            }

            perms = new_perms;
        }

        return perms;
    }
}
