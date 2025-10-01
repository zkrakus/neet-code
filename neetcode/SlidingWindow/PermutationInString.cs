namespace neetcode.SlidingWindow;
public static class PermutationInString
{
    public static bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> charCount = new();
        foreach (char c in s1)
        {
            if (!charCount.ContainsKey(c)) 
                charCount[c] = 1;
            else
                charCount[c]++;
        }

        Dictionary<char, int> windowCharCount = new();
        for (int i = 0; i < s1.Length; i++) {
            if (!windowCharCount.ContainsKey(s2[i]))
                windowCharCount[s2[i]] = 1;
            else
                windowCharCount[s2[i]]++;
        }

        int l = 0, r = 1;
        while (r < s2.Length)
        {
            if (r - l + 1 < s1.Length)
            {
                r++;
                continue;
            }

            l++;
            r++;
        }
    }
}
