namespace neetcode.ArraysAndHashing;
public static class LongestConsecutiveSequence
{
    public static int LongestConsecutive(int[] nums)
    {
        if (nums is null || nums.Length == 0)
            return 0;

        int result = 1;
        HashSet<int> ints = new HashSet<int>(nums);
        foreach (int num in nums)
        {
            if (!ints.Contains(num - 1))
            {
                int length = 1;
                while (ints.Contains(num + length)) {
                    length++;
                }

                result = Math.Max(result, length);
            }
        }

        return result;
    }
}
