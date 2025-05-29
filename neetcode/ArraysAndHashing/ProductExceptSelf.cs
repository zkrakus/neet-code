using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.ArraysAndHashing;
public static class ProductExceptSelf
{
    public static int[] GetProductExceptSelf(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return new int[0];

        int n = nums.Length;
        int[] result = new int[n];
        int[] prefix = new int[n];
        int[] postfix = new int[n];

        prefix[0] = 1;
        for(int i = 1; i < n; i++)
        {
            prefix[i] = prefix[i - 1] * nums[i - 1];
        }

        postfix[n - 1] = 1;
        for(int i = n - 2; i >= 0; i--)
        {
            postfix[i] = postfix[i + 1] * nums[i + 1];
        }

        for(int i = 0; i < n; i++)
        {
            result[i] = prefix[i] * postfix[i];
        }

        return result;
    }

    public static int[] GetProductExceptSelfOneArray(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return new int[0];

        int n = nums.Length;
        int[] result = new int[n];

        result[0] = 1;
        for(int i = 1; i < nums.Length; i++)
        {
            result[i] = nums[i - 1] * result[i - 1];
        }

        var postfix = 1;
        for(int i = n - 2; i <= 0; i--)
        {
            result[i] *= postfix;
            postfix *= nums[i];
        }

        return result;
    }
}
