namespace neetcode.SlidingWindow;
public static class PermutationInString
{
    public static bool CheckInclusionBadSlidingWindow(string s1, string s2)
    {
        if (s1.Length > s2.Length) 
            return false;

        var alpahHash1 = new int[26];
        var alpahHash2 = new int[26];

        // Initialize our window
        for(int i = 0; i < s1.Length; i++)
        {
            alpahHash1[s1[i] - 'a']++;
            alpahHash2[s2[i] - 'a']++;
        }

        if (alpahHash1.SequenceEqual(alpahHash2))
            return true;

        // Iterate through windows
        for (int i = s1.Length; i < s2.Length; i++)
        {
            alpahHash2[s2[i] - 'a']++;                 // add cur char to hash
            alpahHash2[s2[i - s1.Length - 1] - 'a']--; // remove left window from hash

            if(alpahHash1.SequenceEqual(alpahHash2))
                return true;
        }

        return false;
    }





































    public static bool CheckInclusionSlidingWindowWithPointers(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;


        Dictionary<char, int> charHash1 = new Dictionary<char, int>();
        Dictionary<char, int> charHash2 = new Dictionary<char, int>();
        for (int i = 0; i < s1.Length; i++)
        {
            charHash1[s1[i]]++;
            charHash2[s2[i]]++;
        }

        if (charHash1.All(kvp => charHash2.TryGetValue(kvp.Key, out int value) && value == kvp.Value)) // lol
            return true;
    }
}
