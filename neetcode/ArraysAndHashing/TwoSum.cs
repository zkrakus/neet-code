namespace neetcode.ArraysAndHashing;
public static class TwoSum
{
    public static int[] Sum(int[] nums, int target)
    {
        if (nums.Length < 2)
            throw new ArgumentException("Input array must have at least two arguments.");

        var numberIndexDictionary = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            var cur = nums[i];
            var complement = target - cur;

            if (numberIndexDictionary.ContainsKey(complement))
            {
                numberIndexDictionary.TryGetValue(complement, out var j);
                return new int[] { j, i }; 
            } else
            {
                numberIndexDictionary.Add(cur, i);
            }
        }

        throw new InvalidOperationException("Input array must have a solution.");
    }
}
