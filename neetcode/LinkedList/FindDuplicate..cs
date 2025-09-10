namespace neetcode.LinkedList;
public static class FindDuplicate
{
    public static int Find(int[] nums)
    {
        if (nums is null)
            return 0;
        if (nums.Length == 0 || nums.Length == 1)
            return 0;

        // Floyd's algo for cycle detection w/ slow and fast pointers.
        int slow = 0;
        int fast = 0;
        do
        {
            slow = nums[slow]; // step once.
            fast = nums[nums[fast]]; // step twice.
        } while (slow != fast
            && slow < nums.Length && fast < nums.Length); // Don't need this part because of array bounds but, hey.

        // If we walk slow from here we will meet at cycle start.
        slow = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}
