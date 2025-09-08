namespace neetcode.ArraysAndHashing;
public static class ConcatentationOfAnArray
{
    public static int[]? GetConcatenation(int[] nums)
    {
        if (nums is null)
            return null!;

        if (nums.Length == 0)
            return Array.Empty<int>();
        
        var ans = new int[nums.Length * 2];
        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = nums[i];
            ans[nums.Length + i] = nums[i];
        }

        return ans;
    }
}
