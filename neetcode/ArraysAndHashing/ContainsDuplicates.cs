using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.ArraysAndHashing;

/// <summary>
/// Given an integer array nums, return true if any value appears more than once in the array, otherwise return false.
/// </summary>
public static class ContainsDuplicates
{
    /// <summary>
    /// O(n) space. 
    /// O(n) time. We iterate through the array once.
    /// </summary>
    public static bool HasDuplicates1(int[] nums)
    {
        var numSet = new HashSet<int>();

        foreach (int n in nums)
        {
            if (!numSet.Contains(n))
            {
                numSet.Add(n);
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// O(1) space. We don't add more space.
    /// O(n^2) time. We have a nested loops which simplifies to (n^2 - n) / 2
    /// </summary>
    public static bool HasDuplicates2(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// O(1) space. We don't add more space.
    /// O(n + n log(n)) time. We iterate through the array once.
    /// </summary>
    public static bool HasDuplicates3(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            { return true; }
        }

        return false;
    }

    /// <summary>
    /// O(n) space. 
    /// O(n + n log(n)) time. We iterate through the array once.
    /// </summary>
    public static bool HasDuplicates4(int[] nums)
    {
        return nums.ToHashSet().Count != nums.Length;
    }
}
