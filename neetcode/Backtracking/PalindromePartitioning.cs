namespace neetcode.Backtracking;
public static class PalindromePartitioning
{
    public static List<List<string>> PartitionBruteForce(string s)
    {
        var res = new List<List<string>>();
        if (s is null || s.Length == 0)
            return res;

        bool IsPalindrome(int l, int r)
        {
            while (r > l)
            {
                if (s[r] != s[l])
                    return false;

                r--;
                l++;
            }

            return true;
        }

        List<string> part = new();
        void DfsPartitionByPalindrome(int i, int j)
        {
            if (j >= s.Length)
            {
                if (i == j)
                    res.Add(part);

                return;
            }

            if(IsPalindrome(i, j))
            {
                part.Add(s.Substring(i, j - i + 1));
                DfsPartitionByPalindrome(j + 1, j + 1);
                part.RemoveAt(part.Count - 1);
            }

            DfsPartitionByPalindrome(i, j + 1);
        }

        DfsPartitionByPalindrome(0, 0);

        return res;
    }

    // Should try to do the dynamic programming solution.
}
