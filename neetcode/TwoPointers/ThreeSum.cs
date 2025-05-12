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

        int i = 0;
        while (i < numsCopy.Length)
        {
            while (i < numsCopy.Length - 2 && numsCopy[i] == numsCopy[i+1])
                i++;

            int j = i + 1, k = numsCopy.Length - 1;
            while (j < k)
            {
                while (j < k && numsCopy[j] == numsCopy[j + 1])
                    j++;

                while (j < k && numsCopy[k] == numsCopy[k - 1])
                    k--;

                var current = numsCopy[i] + numsCopy[j] + numsCopy[k];
                if (current == 0)
                {
                    result.Add(new List<int>() { i, j, k });
                    i++;
                    j++;
                }

                if (current > 0)
                    k--;

                if (current < 0)
                    j++;
            }
           

            i++;
        }


        return result;
    }
}
