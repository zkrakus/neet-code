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
        if (nums is null || nums.Length == 0)
            return new List<List<int>>() { new List<int>() };

        if(nums.Length == 1)
            return new List<List<int>>() { new List<int> { nums[0] } };


    }
}
