namespace neetcode.SlidingWindow;
public static class LongestRepeatingCharacterReplacement
{
    public static int CharacterReplacementBruteForce(string s, int k)
    {
        if (s is null || s.Length == 0)
            return 0;
        if (k >= s.Length)
            return s.Length;

        int res = 0;
        for(int i = 0; i < s.Length; i++)
        {
            Dictionary<char, int> count = new();
            int maxf = 0;
            for (int j = i; j < s.Length; j++)
            {
                if (count.ContainsKey(s[j]))
                {
                    count[s[j]]++;
                    maxf = Math.Max(maxf, count[s[j]]);
                } 
                else
                {
                    count[s[j]] = 1;
                }

            }
        }

    }

    public static int CharacterReplacement(string s, int k)
    {
        if (s is null || s.Length == 0)
            return 0;
        if (k >= s.Length)
            return s.Length;

        int l = 0, r = 0;
        int res = 0;
        int maxCount = 1;
        Dictionary<char, int> charCount = new();
        while (r < s.Length)
        {
            if (charCount.TryGetValue(s[r], out int count))
            {
                charCount[s[r]]++;
                maxCount = Math.Max(maxCount, count + 1); 
            }
            else
            {
                charCount.Add(s[r], 1);
            }
                
            var windowLength = r - l + 1;
            if(windowLength - maxCount > k)
            {
                charCount[s[l]]--;
            }
            else
            {

            }
        }

        return res;
    }
}
