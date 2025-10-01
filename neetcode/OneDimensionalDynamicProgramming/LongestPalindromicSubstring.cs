using System.ComponentModel;

namespace neetcode.OneDimensionalDynamicProgramming;
public static class LongestPalindromicSubstring
{
    public static string LongestPalindromeBrute(string s)
    {
        if (s is null || s.Length == 0)
            return "";

        int largestLeftIndex = 0;
        int largestPalindromeLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (IsPalindrome(s, i, j) && j - i + 1 > largestPalindromeLength)
                {
                    largestLeftIndex = i;
                    largestPalindromeLength = j - i + 1;
                }
            }
        }

        return s.Substring(largestLeftIndex, largestPalindromeLength);
    }

    public static string LongestPalindromicSubstringMiddleOut(string s)
    {
        if (s is null || s.Length == 0)
            return "";

        int largestLeftIndex = 0;
        int largestPaliLength = 1;
        void IsPalindromeExpansion(int l, int r)
        {
            while (l >= 0 && r < s.Length && (s[l] == s[r]))
            {
                var palindromicLength = r - l + 1;
                if (palindromicLength > largestPaliLength)
                {
                    largestLeftIndex = l;
                    largestPaliLength = palindromicLength;
                }

                l--;
                r++;
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            IsPalindromeExpansion(i, i);
            IsPalindromeExpansion(i, i + 1);
        }

        return s.Substring(largestLeftIndex, largestPaliLength);
    }

    private static bool IsPalindrome(string s, int l, int r)
    {
        while (l < r)
        {
            if (s[l] != s[r])
                return false;

            r--;
            l++;
        }

        return true;
    }
}
