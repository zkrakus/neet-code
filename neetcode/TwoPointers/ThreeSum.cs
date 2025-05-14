using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.TwoPointers;
public class ThreeSum
{
    public static List<List<int>> Sum(int[] nums)
    {
        if (nums is null || nums.Length < 3)
            return new List<List<int>>();

        List<List<int>> result = new();
        int[] numsCopy = nums.ToArray();
        Array.Sort(numsCopy);

        for(int i  = 0; i < numsCopy.Length; i++)
        {
            var val = numsCopy[i];

            if (i > 0 && val == numsCopy[i - 1])
                continue;

            int l = i + 1, r = numsCopy.Length - 1;
            while(l < r)
            {
                var threeSum = val + numsCopy[l] + numsCopy[r];
                if (threeSum > 0)
                    r--;
                else if (threeSum < 0)
                    l++;
                else
                {
                    result.Add(new List<int>() {i, l, r });
                    l++;
                    while (numsCopy[l] == numsCopy[l-1] && l < r)
                    {
                        l++;
                    }
                }
               
            }
        }

        return result;
    }
}
