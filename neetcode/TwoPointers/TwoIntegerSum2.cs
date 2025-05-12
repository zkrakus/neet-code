using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.TwoPointers;
public static class TwoIntegerSum2
{
    public static int[] TwoSum(int[] numbers, int target)
    {
        int i = 0, j = numbers.Length - 1;

        while (j > i)
        {
            var current = numbers[i] + numbers[j];
            if (current == target)
                break;
            else if (current > target)
                j--;
            else if(current < target)
                i++;
        }

        return new int[] { i + 1, j + 1 };
    }
}
