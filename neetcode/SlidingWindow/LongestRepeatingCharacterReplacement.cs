using System.ComponentModel;

namespace neetcode.SlidingWindow;
public static class LongestRepeatingCharacterReplacement
{

    // O(n^2)
    // S(m) : m is the # of unique characters in the string
    public static int CharacterReplacementBruteForce(string s, int k)
    {
        if (s is null || s.Length == 0)
            return 0;
        if (k >= s.Length)
            return k;

        int res = 1;
        for (int i = 0; i < s.Length; i++)
        {
            int lm = 1;
            Dictionary<int, int> charCount = new();
            for (int j = i; j < s.Length; j++)
            {
                if (charCount.TryGetValue(s[j], out var output))
                {
                    charCount[s[j]]++;
                    lm = Math.Max(lm, output);
                }
                else
                {
                    charCount[s[j]]++;
                }

                if (j - i + 1 - lm <= k)
                {
                    res = Math.Max(res, lm);
                }
            }
        }


        return res;
    }

    // T = O(n * m) : m is the number of unique chars in the string.
    // S = O(m)
    public static int CharacterReplacementSlidingWindow(string s, int k)
    {
        if (s is null || s.Length == 0)
            return 0;
        if (k >= s.Length)
            return s.Length;

        int res = 1;
        var uniqueChars = new HashSet<char>(s);
        foreach(char curChar in uniqueChars)
        {
            int l = 0, curCharCount = 0;
            for(int r = 0; r < s.Length; r++)
            {
                if (s[r] == curChar)
                {
                    curCharCount++;
                }

                while (r - l + 1 - curCharCount < k)
                {
                    if (s[l] == curChar)
                    {
                        curCharCount--;
                    }
                    l++;
                }

                res = Math.Max(res, r - l + 1);
            }
        }

        return res;
    }
}
