namespace neetcode.BinarySearch;
public static class FindMedianSortedArrays
{
    public static double Find(int[] nums1, int[] nums2)
    {
        if (nums1 is null) throw new ArgumentNullException(nameof(nums1));
        if (nums2 is null) throw new ArgumentNullException(nameof(nums2));

        var A = nums1;
        var B = nums2;
        if (B.Length < A.Length)
            (A, B) = (B, A);

        int total = A.Length + B.Length;
        int half = total / 2;
        int l = 0, r = A.Length;
        while (l <= r)
        {
            int i = l + (r - l) / 2;
            int j = half - i;

            int Aleft = i > 0 ? A[i - 1] : int.MinValue;
            int Aright = i < A.Length ? A[i] : int.MaxValue;
            int Bleft = j > 0 ? B[j - 1] : int.MinValue;
            int Bright = j < B.Length ? B[j] : int.MaxValue;

            if (Aleft <= Bright && Bleft <= Aright)
            {
                if (total % 2 == 1)
                    return Math.Min(Aright, Bright);

                return (Math.Max(Aleft, Bleft) + Math.Min(Aright, Bright)) / 2.0;
            }
            else if (Aleft > Bright)
                r = i - 1;
            else
                l = i + 1;
        }

        return -1;
    }

















}
