namespace neetcode.SlidingWindow;
public static class LongestRepeatingCharacterReplacement
{

    // O(n^2)
    // S(m) : m is the # of unique characters in the string
    public static int CharacterReplacementBruteForce(string s, int k)
    {
        if (s is null)
            return 0;
        if (k >= s.Length)
            return s.Length;

        var res = 0;
        for(int l = 0; l < s.Length; l++)
        {
            int localMaxCharCount = 1;
            Dictionary<char, int> charCount = new();
            for (int r = l; r < s.Length; l++)
            {
                if (charCount.ContainsKey(s[r]))
                {
                    charCount[s[r]]++;
                    localMaxCharCount = Math.Max(localMaxCharCount, charCount[s[r]]);
                } else
                {
                    charCount[s[r]] = 1;
                }

                if (r - l + 1 - localMaxCharCount <= k)
                {
                    res = Math.Max(res, localMaxCharCount);
                }
            }
        }

        return res;
    }

    public static int CharacterReplacementSlidingWindow(string s, int k)
    {

    }
}
